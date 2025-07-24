
CREATE PROCEDURE registrar_cliente 

	 @identificacion varchar(50)
	,@nombre varchar(200)
	,@telefono varchar(10)
	,@direccion varchar(200)

AS
BEGIN
	INSERT INTO [dbo].[Cliente]
			   ([cli_identificacion]
			   ,[cli_nombre]
			   ,[cli_telefono]
			   ,[cli_direccion])
		 VALUES
			   (@identificacion
			   ,@nombre
			   ,@telefono
			   ,@direccion);
END
