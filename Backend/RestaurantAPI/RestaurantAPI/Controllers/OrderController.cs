using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public OrderController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerOrder>>> GetCustomerOrders()
        {
            return await _context.CustomerOrders
                .Include(x => x.Customer)
                .ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerOrder>> GetCustomerOrder(long id)
        {
            //get fooditem from order details
            var orderDetails = await (from order in _context.Set<CustomerOrder>()
                                      join detail in _context.Set<OrderDetail>()
                                      on order.CustomerOrderId equals detail.CustomerOderId
                                      join foodItem in _context.Set<FoodItem>()
                                      on detail.FoodItemId equals foodItem.FoodItemId
                                      where order.CustomerOrderId == id

                                      select new
                                      {
                                          order.CustomerOrderId,
                                          detail.OrderDetailId,
                                          detail.FoodItemId,
                                          detail.Quantity,
                                          detail.FoodItemPrice,
                                          foodItem.FoodItemName
                                      }).ToListAsync();

            var customerOrder = await (from a in _context.Set<CustomerOrder>()
                                     where a.CustomerOrderId == id

                                     select new
                                     {
                                         a.CustomerOrderId,
                                         a.OrderNumber,
                                         a.CustomerId,
                                         a.PaymentMethod,
                                         a.TotalPrice,
                                         deletedOrderItemIds = "",
                                         orderDetails = orderDetails
                                     }).FirstOrDefaultAsync();

            if (customerOrder == null)
            {
                return NotFound();
            }

            return Ok(customerOrder);
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerOrder(long id, CustomerOrder customerOrder)
        {
            if (id != customerOrder.CustomerOrderId)
            {
                return BadRequest();
            }

            _context.Entry(customerOrder).State = EntityState.Modified;

            //existing food items & newly added food items
            foreach (OrderDetail item in customerOrder.OrderDetails)
            {
                if (item.OrderDetailId == 0)
                    _context.OrderDetails.Add(item);
                else
                    _context.Entry(item).State = EntityState.Modified;
            }

            //deleted food items
            foreach (var i in customerOrder.DeletedOrderItemIds.Split(',').Where(x => x != ""))
            {
                OrderDetail y = _context.OrderDetails.Find(Convert.ToInt64(i));
                _context.OrderDetails.Remove(y);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerOrder>> PostCustomerOrder(CustomerOrder customerOrder)
        {
            _context.CustomerOrders.Add(customerOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerOrder", new { id = customerOrder.CustomerOrderId }, customerOrder);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerOrder(long id)
        {
            CustomerOrder customerOrder = await _context.CustomerOrders.FindAsync(id);
            if (customerOrder == null)
            {
                return NotFound();
            }

            _context.CustomerOrders.Remove(customerOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerOrderExists(long id)
        {
            return _context.CustomerOrders.Any(e => e.CustomerOrderId == id);
        }
    }
}