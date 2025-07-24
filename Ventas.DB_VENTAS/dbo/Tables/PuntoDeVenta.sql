CREATE TABLE [dbo].[PuntoDeVenta] (
    [punven_nit]    VARCHAR (9)   NOT NULL,
    [punven_nombre] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_PuntoDeVenta] PRIMARY KEY CLUSTERED ([punven_nit] ASC)
);

