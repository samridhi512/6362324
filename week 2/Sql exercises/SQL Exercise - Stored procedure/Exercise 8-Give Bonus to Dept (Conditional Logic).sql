CREATE PROCEDURE sp_GiveBonus
@DeptID INT,
@BonusAmount DECIMAL(10,2)
AS
BEGIN
    UPDATE Employees
    SET Salary = Salary + @BonusAmount
    WHERE DepartmentID = @DeptID;
END;
GO


EXEC sp_GiveBonus 2, 1000.00;
SELECT * FROM Employees WHERE DepartmentID = 2;
