CREATE PROCEDURE [dbo].[registrar_venta]
    @codigo VARCHAR(20),
    @fecha DATETIME, 
    @cli_identificacion VARCHAR(50),
    @punven_nit VARCHAR(9),
    @producto VARCHAR(20),
    @total DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Venta (
        ven_codigo,
        ven_fecha,
        ven_cli_identificacion,
        ven_punven_nit,
        ven_producto,
        ven_total
    )
    VALUES (
        @codigo,
        @fecha,
        @cli_identificacion,
        @punven_nit,
        @producto,
        @total
    );
END;