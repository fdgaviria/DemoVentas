CREATE PROCEDURE consultar_ventas
AS
BEGIN
	SELECT 
	 ven_codigo
	,ven_fecha
	,cli_nombre
	,punven_nombre
	,ven_producto
	,ven_total
	FROM [dbo].[Venta]
	JOIN [dbo].[Cliente]	ON ven_cli_identificacion = [cli_identificacion]
	JOIN [dbo].[PuntoDeVenta] ON ven_punven_nit = punven_nit
			 
END
