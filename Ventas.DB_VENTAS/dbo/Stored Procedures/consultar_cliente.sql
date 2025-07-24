CREATE PROCEDURE consultar_cliente 
AS
BEGIN
	SELECT 
			[cli_identificacion]
			,[cli_nombre]
			,[cli_telefono]
			,[cli_direccion]
	FROM [dbo].[Cliente]
			 
END
