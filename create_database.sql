-- =========================================================
-- SCRIPT DE CREACIÓN DE TABLAS DEL MODELO DE DATOS
-- Proyecto: Sistema de Control de Gastos Personales
-- Autor: Dairo Arenas Giraldo, Juan Pablo Colorado
-- Fecha: 2025-04-07
-- =========================================================

CREATE DATABASE gestion_gastos

-- Tabla: Usuarios
-- Esta tabla almacena a los usuarios del sistema. Cada usuario tiene:
-- - Un identificador único (Id)
-- - Nombre
-- - Correo electrónico (único)
-- - Contraseña cifrada (hash bcrypt para mayor seguridad)
-- - Fecha en que se registró
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),                          
    Nombre NVARCHAR(100) NOT NULL,                             
    Email NVARCHAR(100) NOT NULL UNIQUE,                       
    PasswordHash NVARCHAR(MAX) NOT NULL,                       
    FechaRegistro DATETIME NOT NULL                            
);

-- Tabla: Categorías
-- Aquí se almacenan las diferentes categorías que los usuarios pueden usar
-- para clasificar sus gastos o presupuestos.
-- Por ejemplo: Comida, Transporte, Salud, etc.
CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY(1,1),                          
    Nombre NVARCHAR(100) NOT NULL,                             
    Descripcion NVARCHAR(255)                                  
);

-- Tabla: Monedas
-- Tabla para registrar las monedas aceptadas en el sistema.
-- Esto permite que el sistema sea multi-divisa.
CREATE TABLE Monedas (
    Id INT PRIMARY KEY IDENTITY(1,1),                          
    Codigo NVARCHAR(10) NOT NULL,                              
    Nombre NVARCHAR(50) NOT NULL,                              
    Simbolo NVARCHAR(10) NOT NULL                              
);

-- Tabla: Gastos
-- Esta tabla almacena los gastos hechos por los usuarios.
-- Se relaciona con:
-- - Usuarios: quién hizo el gasto
-- - Categorías: de qué tipo fue el gasto
-- - Monedas: en qué moneda fue registrado
-- Contiene también el monto, fecha y una descripción opcional.
CREATE TABLE Gastos (
    Id INT PRIMARY KEY IDENTITY(1,1),                          
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id),         
    CategoriaId INT FOREIGN KEY REFERENCES Categorias(Id),     
    MonedaId INT FOREIGN KEY REFERENCES Monedas(Id),           
    Monto DECIMAL(18, 2) NOT NULL,                             
    Fecha DATETIME NOT NULL,                                   
    Descripcion NVARCHAR(255)                                  
);

-- Tabla: Presupuestos
-- En esta tabla los usuarios registran presupuestos por categoría.
-- Pueden definir límites de gasto entre fechas específicas.
CREATE TABLE Presupuestos (
    Id INT PRIMARY KEY IDENTITY(1,1),                          
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id),         
    CategoriaId INT FOREIGN KEY REFERENCES Categorias(Id),     
    MonedaId INT FOREIGN KEY REFERENCES Monedas(Id),           
    Limite DECIMAL(18, 2) NOT NULL,                            
    FechaInicio DATETIME NOT NULL,                             
    FechaFin DATETIME NOT NULL                                 
);
