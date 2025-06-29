DROP PROCEDURE sp_InsertEmployee;
GO


EXEC sp_InsertEmployee 'Test', 'Delete', 1, 4000.00, '2022-01-01'; -- should give error
