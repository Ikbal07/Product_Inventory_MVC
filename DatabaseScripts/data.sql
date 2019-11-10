INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'11a8e9df-027e-4709-bb98-0a50ce92f6e9', N'admin@inventory.com', N'ADMIN@INVENTORY.COM', N'admin@inventory.com', N'ADMIN@INVENTORY.COM', 0, N'AQAAAAEAACcQAAAAEDWu8BBS6yMs39BBdxk9uU5EucV7prwXV41sggjG3HU1MkW1fw8xVENtR9KCGIar6Q==', N'XBD2IYBI5MVNZVGS4NMPEKRGT5V5J3JD', N'884671d6-9caa-4f6c-96de-255be90bea8d', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[ProductCategory] ON
INSERT INTO [dbo].[ProductCategory] ([Id], [Name], [Description]) VALUES (1, N'Furniture', N'Furniture Items')
INSERT INTO [dbo].[ProductCategory] ([Id], [Name], [Description]) VALUES (2, N'Electronic and Electrical ', N'Electronic and Electrical  Products')
INSERT INTO [dbo].[ProductCategory] ([Id], [Name], [Description]) VALUES (3, N'Toys ', N'Toys ')
INSERT INTO [dbo].[ProductCategory] ([Id], [Name], [Description]) VALUES (4, N'Foot ware', N'Foot Ware ')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT INTO [dbo].[Product] ([Id], [ProductName], [Price], [ProductCategoryId]) VALUES (1, N'Teddy', CAST(30.00 AS Decimal(18, 2)), 3)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [Price], [ProductCategoryId]) VALUES (2, N'Dinner Table', CAST(400.00 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [Price], [ProductCategoryId]) VALUES (3, N'Lawn Mower', CAST(300.00 AS Decimal(18, 2)), 2)
INSERT INTO [dbo].[Product] ([Id], [ProductName], [Price], [ProductCategoryId]) VALUES (4, N'Apple iPhone 8', CAST(900.00 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Retailer] ON
INSERT INTO [dbo].[Retailer] ([Id], [Name], [ContactNumber]) VALUES (1, N'ABC Electronics', N'02134589076')
INSERT INTO [dbo].[Retailer] ([Id], [Name], [ContactNumber]) VALUES (2, N'Toys R Us', N'02145671234')
INSERT INTO [dbo].[Retailer] ([Id], [Name], [ContactNumber]) VALUES (3, N'City Furniture', N'02134213555')
SET IDENTITY_INSERT [dbo].[Retailer] OFF
SET IDENTITY_INSERT [dbo].[ProductRetailerRegistration] ON
INSERT INTO [dbo].[ProductRetailerRegistration] ([Id], [ProductId], [RetailerId], [DeliveryStatus]) VALUES (1, 1, 1, 1)
INSERT INTO [dbo].[ProductRetailerRegistration] ([Id], [ProductId], [RetailerId], [DeliveryStatus]) VALUES (2, 2, 3, 0)
SET IDENTITY_INSERT [dbo].[ProductRetailerRegistration] OFF
