USE [product]
GO
/****** Object:  Sequence [dbo].[seqCategory]    Script Date: 20.04.2019 16:26:04 ******/
CREATE SEQUENCE [dbo].[seqCategory] 
 AS [bigint]
 START WITH 7
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO
/****** Object:  Sequence [dbo].[seqProduct]    Script Date: 20.04.2019 16:26:04 ******/
CREATE SEQUENCE [dbo].[seqProduct] 
 AS [bigint]
 START WITH 15
 INCREMENT BY 1
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
GO

/****** Object:  Table [dbo].[Category]    Script Date: 20.04.2019 16:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [bigint] NOT NULL,
	[CategoryName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 20.04.2019 16:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [bigint] NOT NULL,
	[ProductName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 20.04.2019 16:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductId] [bigint] NOT NULL,
	[CategoryId] [bigint] NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Бытовая техника')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Электроника')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Бытовая химия')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Инструменты')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (5, N'Хозтовары')
GO
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (6, N'Товары для животных')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (1, N'Чипсы')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (2, N'Бананы')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (3, N'Хлеб')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (4, N'Фотоаппарат')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (5, N'Стиральная машина')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (6, N'Пылесос')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (7, N'Телевизор')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (8, N'Радио')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (9, N'Духовой шкаф')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (10, N'Молоток')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (11, N'Отвертка')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (12, N'Скотч-лента')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (13, N'Аудио-колонка')
GO
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (14, N'Мыло')
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (4, 2)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (5, 1)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (5, 2)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (6, 1)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (6, 2)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (7, 2)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (8, 2)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (9, 1)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (10, 4)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (10, 5)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (11, 4)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (11, 5)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (12, 5)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (13, 2)
GO
INSERT [dbo].[ProductCategory] ([ProductId], [CategoryId]) VALUES (14, 3)
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_CategoryId]  DEFAULT (NEXT VALUE FOR [seqCategory]) FOR [CategoryId]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_ProductId]  DEFAULT (NEXT VALUE FOR [seqProduct]) FOR [ProductId]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Категории' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Продукты' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Категории продуктов' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProductCategory'
GO
