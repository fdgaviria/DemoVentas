CREATE TABLE [dbo].[Venta] (
    [ven_codigo]             VARCHAR (20)    NOT NULL,
    [ven_fecha]              DATETIME        NOT NULL,
    [ven_cli_identificacion] VARCHAR (50)    NOT NULL,
    [ven_punven_nit]         VARCHAR (9)     NOT NULL,
    [ven_producto]           VARCHAR (20)    NOT NULL,
    [ven_total]              DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED ([ven_codigo] ASC),
    CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY ([ven_cli_identificacion]) REFERENCES [dbo].[Cliente] ([cli_identificacion]),
    CONSTRAINT [FK_Venta_PuntoDeVenta] FOREIGN KEY ([ven_punven_nit]) REFERENCES [dbo].[PuntoDeVenta] ([punven_nit])
);

