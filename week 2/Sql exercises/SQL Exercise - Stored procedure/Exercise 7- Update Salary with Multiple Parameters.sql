CREATE PROCEDURE sp_UpdateEmployeeSalary
@EmpID INT,
@NewSalary DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees
    SET Salary = @NewSalary
    WHERE EmployeeID = @EmpID;
END;
GO


EXEC sp_UpdateEmployeeSalary 1, 7500.00;
SELECT * FROM Employees WHERE EmployeeID = 1;
