
CREATE FUNCTION fn_CalculateAnnualSalary (@Salary DECIMAL(10,2))
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Salary * 12;
END;
GO  
SELECT FirstName, LastName, Salary, dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;
