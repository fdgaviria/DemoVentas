CREATE TABLE [dbo].[Cliente] (
    [cli_identificacion] VARCHAR (50)  NOT NULL,
    [cli_nombre]         VARCHAR (200) NOT NULL,
    [cli_telefono]       VARCHAR (10)  NOT NULL,
    [cli_direccion]      VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([cli_identificacion] ASC)
);

