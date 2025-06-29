CREATE PROCEDURE sp_TotalSalaryByDepartment
@DeptID INT,
@TotalSalary DECIMAL(10,2) OUTPUT
AS
BEGIN
    SELECT @TotalSalary = SUM(Salary)
    FROM Employees
    WHERE DepartmentID = @DeptID;
END;
GO


DECLARE @SalaryOut DECIMAL(10,2);
EXEC sp_TotalSalaryByDepartment 2, @SalaryOut OUTPUT;
SELECT @SalaryOut AS TotalSalary;
