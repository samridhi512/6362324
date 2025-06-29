CREATE PROCEDURE sp_GetEmployeesByFilter
@FilterColumn NVARCHAR(100),
@FilterValue NVARCHAR(100)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = 'SELECT * FROM Employees WHERE ' + QUOTENAME(@FilterColumn) + ' = @value';

    EXEC sp_executesql @SQL, N'@value NVARCHAR(100)', @value = @FilterValue;
END;
GO


EXEC sp_GetEmployeesByFilter 'DepartmentID', '3';
