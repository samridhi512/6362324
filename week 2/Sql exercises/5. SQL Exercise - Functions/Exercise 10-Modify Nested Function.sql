SELECT FirstName, Salary, dbo.fn_CalculateTotalCompensation(Salary) AS TotalCompensation
FROM Employees;
