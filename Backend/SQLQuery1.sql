SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (1, N'Emanuel Kosowski')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (2, N'Andrzej Kowalski')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (3, N'Nobert Kubicha')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (4, N'Marek Podzianowski')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (5, N'Karolina Wojtyla')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (6, N'Maciek Gortyt')
GO
INSERT [dbo].[Customers] ([CustomerId], [CustomerName]) VALUES (7, N'Krystian Tynic')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodItems] ON 
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (1, N'Skrzydełka z kurczaka', CAST(14.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (2, N'Skrzydełka z kurczaka w zestawie (napój, frytki)', CAST(21.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (3, N'Burger wołowy', CAST(21.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (4, N'Burger wołowy w zestawie (napój, frytki)', CAST(28.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (5, N'Burger z kurczaczkami w panierce', CAST(21.49 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (6, N'Burger z kurczaczkami w panierce w zestawie (napój, frytki)', CAST(28.49 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (7, N'Spaghetti', CAST(17.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (8, N'Zupa pomidorowa', CAST(9.49 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (9, N'Zupa ogórkowa', CAST(10.49 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (10, N'Frytki', CAST(9.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (11, N'Bataty', CAST(13.49 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (12, N'Lemoniada', CAST(8.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (13, N'Coca-cola', CAST(7.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[FoodItems] ([FoodItemId], [FoodItemName], [Price]) VALUES (14, N'Coca-cola zero', CAST(7.99 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[FoodItems] OFF
GO