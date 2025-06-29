CREATE PROCEDURE sp_SafeSalaryUpdate
@EmpID INT,
@NewSalary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmployeeID = @EmpID)
            THROW 50001, 'Error: Employee not found.', 1;

        UPDATE Employees
        SET Salary = @NewSalary
        WHERE EmployeeID = @EmpID;
    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;
GO


EXEC sp_SafeSalaryUpdate 1, 9100.00;
SELECT * FROM Employees WHERE EmployeeID = 1;


EXEC sp_SafeSalaryUpdate 999, 9100.00;
