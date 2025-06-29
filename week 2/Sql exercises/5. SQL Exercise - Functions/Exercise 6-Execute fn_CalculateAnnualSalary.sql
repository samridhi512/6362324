SELECT FirstName, Salary, dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;
