CREATE PROCEDURE sp_GetEmployeesByDepartment
@DeptID INT
AS
BEGIN
    SELECT EmployeeID, FirstName, LastName, Salary
    FROM Employees
    WHERE DepartmentID = @DeptID;
END;
GO


EXEC sp_GetEmployeesByDepartment 2;
