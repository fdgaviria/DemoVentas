CREATE PROCEDURE [dbo].[eliminar_venta]
    @codigo VARCHAR(20)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Venta WHERE ven_codigo = @codigo)
    BEGIN
        RETURN -1; -- no existe
    END

    DELETE FROM Venta
    WHERE ven_codigo = @codigo;

    IF @@ROWCOUNT = 0
    BEGIN
        RETURN 1; -- no se pudo eliminar
    END
    ELSE
    BEGIN
        RETURN 0; -- ok
    END
END;