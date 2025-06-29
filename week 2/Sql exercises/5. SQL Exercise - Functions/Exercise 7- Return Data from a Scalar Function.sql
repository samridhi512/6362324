
DECLARE @Salary DECIMAL(10,2);
SELECT @Salary = Salary FROM Employees WHERE EmployeeID = 1;
SELECT dbo.fn_CalculateAnnualSalary(@Salary) AS AnnualSalary;
