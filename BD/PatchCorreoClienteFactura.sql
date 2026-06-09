USE PUPUSERIA;
GO

IF COL_LENGTH('VENTA.CLIENTE', 'CorreoElectronico') IS NULL
BEGIN
    ALTER TABLE VENTA.CLIENTE
    ADD CorreoElectronico VARCHAR(100) NULL;
END
GO

IF OBJECT_ID(N'VENTA.SpInsertCliente', N'P') IS NOT NULL
    DROP PROCEDURE VENTA.SpInsertCliente;
GO
CREATE PROCEDURE VENTA.SpInsertCliente
    @Nombre VARCHAR(25),
    @Apellido VARCHAR(25),
    @Telefono VARCHAR(10),
    @CorreoElectronico VARCHAR(100) = NULL,
    @DireccionId INT,
    @EstadoId INT,
    @UsuarioRegistroId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
    BEGIN
        RAISERROR('La direccion no existe.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM VENTA.CLIENTE WHERE Telefono = @Telefono AND DireccionId = @DireccionId)
    BEGIN
        RAISERROR('El cliente ya existe con esa direccion.', 16, 1);
        RETURN;
    END

    DECLARE @NombreBase VARCHAR(50) = @Nombre + ' ' + @Apellido;
    DECLARE @Count INT;
    SELECT @Count = COUNT(*) FROM VENTA.CLIENTE WHERE Telefono = @Telefono;

    DECLARE @NombreCompleto VARCHAR(100);
    IF @Count > 0
        SET @NombreCompleto = @NombreBase + ' (' + CAST(@Count + 1 AS VARCHAR) + ')';
    ELSE
        SET @NombreCompleto = @NombreBase;

    INSERT INTO VENTA.CLIENTE(Nombre, Apellido, NombreCompleto, Telefono, CorreoElectronico, DireccionId, EstadoId, UsuarioRegistroId)
    VALUES (@Nombre, @Apellido, @NombreCompleto, @Telefono, @CorreoElectronico, @DireccionId, @EstadoId, @UsuarioRegistroId);
END
GO

IF OBJECT_ID(N'VENTA.SpUpdateCliente', N'P') IS NOT NULL
    DROP PROCEDURE VENTA.SpUpdateCliente;
GO
CREATE PROCEDURE VENTA.SpUpdateCliente
    @ClienteId INT,
    @Nombre VARCHAR(25),
    @Apellido VARCHAR(25),
    @NombreCompleto VARCHAR(100),
    @Telefono VARCHAR(10),
    @CorreoElectronico VARCHAR(100) = NULL,
    @DireccionId INT,
    @EstadoId INT,
    @UsuarioModificacionId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM VENTA.CLIENTE WHERE ClienteId = @ClienteId)
    BEGIN
        RAISERROR('El cliente no ha sido encontrado.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS(SELECT 1 FROM DELIVERY.DIRECCION WHERE DireccionId = @DireccionId)
    BEGIN
        RAISERROR('La direccion no existe.', 16, 1);
        RETURN;
    END

    IF EXISTS(SELECT 1 FROM VENTA.CLIENTE WHERE Telefono = @Telefono AND DireccionId = @DireccionId AND ClienteId <> @ClienteId)
    BEGIN
        RAISERROR('Ya existe otro cliente con ese telefono en la misma direccion.', 16, 1);
        RETURN;
    END

    UPDATE VENTA.CLIENTE
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        NombreCompleto = @NombreCompleto,
        Telefono = @Telefono,
        CorreoElectronico = @CorreoElectronico,
        DireccionId = @DireccionId,
        EstadoId = @EstadoId,
        UsuarioModificacionId = @UsuarioModificacionId
    WHERE ClienteId = @ClienteId;
END
GO

IF OBJECT_ID(N'VENTA.SpSelectAllCliente', N'P') IS NOT NULL
    DROP PROCEDURE VENTA.SpSelectAllCliente;
GO
CREATE PROCEDURE VENTA.SpSelectAllCliente
AS
BEGIN
    SET NOCOUNT ON;

    SELECT a.ClienteId,
           a.Nombre,
           a.Apellido,
           a.NombreCompleto,
           a.Telefono,
           a.CorreoElectronico,
           a.DireccionId,
           (SELECT d.Nombre + ', ' + b.ColoniBarrio
            FROM DELIVERY.DIRECCION b
            INNER JOIN DELIVERY.MUNICIPIO d ON b.MunicipioId = d.MunicipioId
            WHERE b.DireccionId = a.DireccionId) AS DireccionNombre,
           (SELECT b.PuntoReferencia
            FROM DELIVERY.DIRECCION b
            WHERE b.DireccionId = a.DireccionId) AS PuntoReferencia,
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM VENTA.CLIENTE a
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    ORDER BY a.NombreCompleto;
END
GO

IF OBJECT_ID(N'VENTA.SpSelectCliente', N'P') IS NOT NULL
    DROP PROCEDURE VENTA.SpSelectCliente;
GO
CREATE PROCEDURE VENTA.SpSelectCliente
    @Buscar VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT a.ClienteId,
           a.Nombre,
           a.Apellido,
           a.NombreCompleto,
           a.Telefono,
           a.CorreoElectronico,
           a.DireccionId,
           (SELECT d.Nombre + ', ' + b.ColoniBarrio
            FROM DELIVERY.DIRECCION b
            INNER JOIN DELIVERY.MUNICIPIO d ON b.MunicipioId = d.MunicipioId
            WHERE b.DireccionId = a.DireccionId) AS DireccionNombre,
           (SELECT b.PuntoReferencia
            FROM DELIVERY.DIRECCION b
            WHERE b.DireccionId = a.DireccionId) AS PuntoReferencia,
           a.EstadoId,
           c.Estado AS EstadoNombre
    FROM VENTA.CLIENTE a
    INNER JOIN GLOBAL.ESTADO c ON a.EstadoId = c.EstadoId
    WHERE a.NombreCompleto LIKE '%' + @Buscar + '%'
       OR a.Telefono LIKE '%' + @Buscar + '%'
       OR a.CorreoElectronico LIKE '%' + @Buscar + '%'
    ORDER BY a.NombreCompleto;
END
GO
