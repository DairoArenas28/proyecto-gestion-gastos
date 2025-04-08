-- =========================================================
-- SCRIPT DE INSERCIÓN DE DATOS CON COMENTARIOS DETALLADOS
-- Proyecto: Sistema de Control de Gastos Personales
-- Autor: Dairo Arenas Giraldo, Juan Pablo Colorado
-- Fecha: 2025-04-07
-- =========================================================

-- ===============================
-- Insertar datos en la tabla Usuarios
-- ===============================
-- Insertamos 10 usuarios con su nombre, correo, contraseña (hash) y fecha de registro
-- Nota: PasswordHash se representa con texto simulado de hashes bcrypt
INSERT INTO Usuarios (Nombre, Email, PasswordHash, FechaRegistro) VALUES
('Juan Pérez', 'juan.perez@email.com', '$2b$10$W3sD2T1g6V9e12xLMjY0OOkMCLh1RcF0PCx7Lg9OTRR1CpU/Mea1C', '2024-01-01'),
('Ana Gómez', 'ana.gomez@email.com', '$2b$10$kf2w4Q18Z9poR8hgLR9aN.xMQrsOdpjBe1c01GeW1c9T3RQmjO8C2', '2024-01-02'),
('Luis Torres', 'luis.torres@email.com', '$2b$10$kK5L2uG1zK7V16PYq1M3FOPZ6MJ3/jPYbwC9vVz6QW6cAXsOsMQSG', '2024-01-03'),
('Marta Ruiz', 'marta.ruiz@email.com', '$2b$10$FJ9Ll92K2TfI67R8MmDOueMxwBtXD5M28U.SclY7U3VvAqx6MUNj6', '2024-01-04'),
('Pedro Sánchez', 'pedro.sanchez@email.com', '$2b$10$7zpc0ROQG67o.1Mqz7guFeGdh2IlRQWz9Yu7DsC5UgGpBF4gIKCkW', '2024-01-05'),
('Laura Díaz', 'laura.diaz@email.com', '$2b$10$K1L9TQP3OOCj0DZfR7dtdOZqIlRWc0JK4sbSH1Q7MmK7LLhndI6zO', '2024-01-06'),
('Carlos López', 'carlos.lopez@email.com', '$2b$10$8wMx0e2Qq.5AvjsYROUNMeiHeuZGRNu3mvzBSWmRgHX1C7P1peKFa', '2024-01-07'),
('Elena Castro', 'elena.castro@email.com', '$2b$10$5aR96cG9Lwl1HTbGJPLqdu5D8Vo2tcA6uwUS4MuaxrTQYRT/vyhgq', '2024-01-08'),
('Diego Ramírez', 'diego.ramirez@email.com', '$2b$10$nU6U1qVTRdOxvh72ZCD54OaCku6GBF.vdp8q6PQK0a4mKrQNK.RVu', '2024-01-09'),
('Sofía Herrera', 'sofia.herrera@email.com', '$2b$10$fN4w7GDM6V9YlPZB2ZQeYuG9w0ZGLDJbItOg/74jLvH1FTr3TZJQC', '2024-01-10');

-- ===============================
-- Insertar datos en la tabla Categorías
-- ===============================
-- Cada categoría representa un tipo de gasto común
INSERT INTO Categorias (Nombre, Descripcion) VALUES
('Comida', 'Gastos relacionados con alimentos y restaurantes'),
('Transporte', 'Gastos en transporte y movilidad'),
('Entretenimiento', 'Cine, conciertos, etc.'),
('Educación', 'Libros, cursos, matrícula'),
('Salud', 'Medicinas, consultas, seguros'),
('Ropa', 'Prendas de vestir'),
('Hogar', 'Limpieza, decoración, muebles'),
('Tecnología', 'Computadoras, gadgets, apps'),
('Servicios', 'Agua, luz, internet'),
('Viajes', 'Pasajes, hoteles, tours');

-- ===============================
-- Insertar datos en la tabla Monedas
-- ===============================
-- Esta tabla define el tipo de moneda usada para gastos y presupuestos
INSERT INTO Monedas (Codigo, Nombre, Simbolo) VALUES
('USD', 'Dólar estadounidense', '$'),
('EUR', 'Euro', '€'),
('COP', 'Peso colombiano', '$'),
('MXN', 'Peso mexicano', '$'),
('BRL', 'Real brasileño', 'R$'),
('CLP', 'Peso chileno', '$'),
('ARS', 'Peso argentino', '$'),
('PEN', 'Sol peruano', 'S/'),
('GBP', 'Libra esterlina', '£'),
('JPY', 'Yen japonés', '¥');

-- ===============================
-- Insertar datos en la tabla Gastos
-- ===============================
-- Se registran 10 gastos con su respectivo usuario, categoría y moneda
INSERT INTO Gastos (UsuarioId, CategoriaId, MonedaId, Monto, Fecha, Descripcion) VALUES
(1, 1, 1, 20.50, '2024-03-01', 'Almuerzo'),
(2, 2, 2, 15.00, '2024-03-02', 'Bus'),
(3, 3, 3, 50.00, '2024-03-03', 'Cine'),
(4, 4, 4, 120.00, '2024-03-04', 'Curso online'),
(5, 5, 5, 30.00, '2024-03-05', 'Consulta médica'),
(6, 6, 6, 40.00, '2024-03-06', 'Camisa nueva'),
(7, 7, 7, 60.00, '2024-03-07', 'Decoración hogar'),
(8, 8, 8, 250.00, '2024-03-08', 'Celular nuevo'),
(9, 9, 9, 75.00, '2024-03-09', 'Factura de luz'),
(10, 10, 10, 500.00, '2024-03-10', 'Viaje a Tokio');

-- ===============================
-- Insertar datos en la tabla Presupuestos
-- ===============================
-- Cada usuario tiene un presupuesto asignado por categoría y moneda
INSERT INTO Presupuestos (UsuarioId, CategoriaId, MonedaId, Limite, FechaInicio, FechaFin) VALUES
(1, 1, 1, 200.00, '2024-03-01', '2024-03-31'),
(2, 2, 2, 150.00, '2024-03-01', '2024-03-31'),
(3, 3, 3, 100.00, '2024-03-01', '2024-03-31'),
(4, 4, 4, 300.00, '2024-03-01', '2024-03-31'),
(5, 5, 5, 250.00, '2024-03-01', '2024-03-31'),
(6, 6, 6, 180.00, '2024-03-01', '2024-03-31'),
(7, 7, 7, 220.00, '2024-03-01', '2024-03-31'),
(8, 8, 8, 500.00, '2024-03-01', '2024-03-31'),
(9, 9, 9, 90.00, '2024-03-01', '2024-03-31'),
(10, 10, 10, 1000.00, '2024-03-01', '2024-03-31');
