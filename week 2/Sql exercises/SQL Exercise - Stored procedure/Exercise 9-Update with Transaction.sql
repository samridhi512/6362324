CREATE PROCEDURE sp_TransactionalSalaryUpdate
@EmpID INT,
@NewSalary DECIMAL(10,2)
AS
BEGIN
    BEGIN TRANSACTION;
    UPDATE Employees
    SET Salary = @NewSalary
    WHERE EmployeeID = @EmpID;

    IF @@ERROR <> 0
    BEGIN
        ROLLBACK;
        PRINT 'Update failed';
    END
    ELSE
    BEGIN
        COMMIT;
        PRINT 'Update succeeded';
    END
END;
GO


EXEC sp_TransactionalSalaryUpdate 3, 8800.00;
SELECT * FROM Employees WHERE EmployeeID = 3;
