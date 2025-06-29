CREATE PROCEDURE sp_TotalEmployeesInDepartment
@DeptID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DeptID;
END;
GO


EXEC sp_TotalEmployeesInDepartment 2;
