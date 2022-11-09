SELECT name AS Customers FROM Customers
LEFT JOIN Orders on Customers.id=Orders.customerId
WHERE Orders.id IS NULL