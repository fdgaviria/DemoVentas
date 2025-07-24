CREATE PROCEDURE [dbo].[consultar_venta_codigo]
    @codigo VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ven_codigo,
        ven_fecha,
        ven_cli_identificacion,
        ven_punven_nit,
        ven_producto,
        ven_total
    FROM
        [dbo].[Venta]
    WHERE
        ven_codigo = @codigo;
END;