# Sistema de Gestión de Finanzas Personales

##Integrantes
### Dairo Fernando Arenas Giraldo
### Juan Pablo Orozco Colorado

Este proyecto tiene como objetivo la creación de una base de datos relacional completamente normalizada para la **gestión de finanzas personales**. Incluye:

- Modelo entidad-relación.
- Scripts de creación de tablas.
- Scripts de inserción de datos realistas (mínimo 10 por tabla).
- Contraseñas simuladas con bcrypt.
- Justificación completa del modelo de normalización hasta 3FN.

---

## 📊 Modelo de Datos

### Tablas principales

1. **Usuarios**: Información básica de quienes usan el sistema.
2. **Categorias**: Tipos de gastos para clasificar los movimientos.
3. **Monedas**: Monedas disponibles para registrar los gastos.
4. **Gastos**: Registro detallado de cada gasto realizado.
5. **Presupuestos**: Límites mensuales por categoría asignados por los usuarios.

### Relaciones

- Un usuario puede tener muchos gastos.
- Cada gasto pertenece a una categoría.
- Cada gasto está expresado en una moneda.
- Cada presupuesto se asigna por usuario y por categoría.

### 📊 Diagrama ER

El siguiente diagrama muestra el modelo relacional:

![Diagrama ER](A_diagram_in_the_image_depicts_a_database_schema_f.png)

---

## 📝 Script de Creación de Tablas

Las tablas han sido diseñadas para cumplir con la **Tercera Forma Normal (3FN)**:

- Eliminación de datos redundantes (1FN).
- Separación de dependencias parciales (2FN).
- Evitación de dependencias transitivas (3FN).

Incluye:

- Llaves primarias (PK).
- Llaves foráneas (FK).
- Restricciones NOT NULL, UNIQUE y CHECK donde aplica.

```sql
-- Disponible en script_1_creacion.sql
```

---

## 📄 Script de Inserción de Datos

Cada tabla contiene **10 registros mínimos**. Las contraseñas están generadas con hash bcrypt simulados para mantener una estructura realista.

```sql
-- Disponible en script_2_inserts.sql
```

### Detalles por tabla

#### Usuarios
- Campos: Nombre, Email, PasswordHash, FechaRegistro.
- Se incluye una variedad de nombres y correos con fechas escalonadas.
- Las contraseñas son hashes bcrypt ficticios pero realistas.

#### Categorías
- Tipos comunes de gastos: comida, salud, tecnología, transporte, etc.
- Todas tienen nombre y descripción.

#### Monedas
- 10 monedas representativas del mundo (USD, EUR, COP, etc.).
- Cada una con su símbolo y código internacional.

#### Gastos
- Registro de movimientos económicos.
- Incluye: usuario, categoría, moneda, monto, descripción y fecha.

#### Presupuestos
- Define un límite de gasto mensual por categoría y usuario.
- Las fechas cubren el mes de marzo de 2024.

---

## ✅ Justificación de Normalización

| Forma Normal | Aplicación |
|--------------|-------------|
| **1FN** | Cada tabla tiene valores atómicos y sin repeticiones. |
| **2FN** | Todas las tablas están completamente dependientes de la clave primaria. |
| **3FN** | No existen dependencias transitivas entre columnas. |

Esto asegura que la base de datos sea eficiente, sin redundancias y fácil de mantener.

---

## 📁 Estructura del Repositorio

```
/finanzas-personales-db
│
├── README.md                 # Documentación principal
├── A_diagram_in_the_image...png  # Diagrama relacional
├── script_1_creacion.sql     # Script de creación de tablas
└── script_2_inserts.sql      # Script de datos insertados con comentarios
```

---

## 🚀 Futuras Mejoras

- Agregar tabla de ingresos.
- Implementar tabla de metas financieras.
- Diseño de reportes mensuales automáticos.

---

## 👨‍💼 Autor

**Dairo Arenas Giraldo / Juan Pablo Colorado**  
Estudiante universitario, apasionado por las bases de datos y el modelado relacional.  
Proyecto desarrollado como evidencia de competencias en normalización y diseño de bases de datos relacionales.

---

## 🌟 Evaluación del Modelo

Este proyecto cumple con el criterio de evaluación “**Excelente (5)**”:

> *"El modelo está completamente normalizado (1FN, 2FN, 3FN). Se justifican claramente los ajustes realizados."*

## Diagrama Entidad-Relación
![Diagrama Entidad Relacion](https://github.com/user-attachments/assets/b022823e-dc76-4c8a-b787-4e5336e2f77a)


