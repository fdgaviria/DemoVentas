CREATE PROCEDURE [dbo].[actualizar_venta]
    @codigo VARCHAR(20),
    @fecha DATETIME,
    @cli_identificacion VARCHAR(50),
    @punven_nit VARCHAR(9),
    @producto VARCHAR(20),
    @total DECIMAL(18, 2)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Venta WHERE ven_codigo = @codigo)
    BEGIN
        RETURN -1; 
    END

    UPDATE Venta
    SET
        ven_fecha = @fecha,
        ven_cli_identificacion = @cli_identificacion,
        ven_punven_nit = @punven_nit,
        ven_producto = @producto,
        ven_total = @total
    WHERE
        ven_codigo = @codigo;
   
END;