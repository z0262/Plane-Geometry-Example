SELECT a.ProductName,b.CategoryName 
FROM Product a LEFT OUTER JOIN ProductCategory c ON a.ProductId=c.ProductId
LEFT OUTER JOIN Category b ON c.CategoryId=b.CategoryId