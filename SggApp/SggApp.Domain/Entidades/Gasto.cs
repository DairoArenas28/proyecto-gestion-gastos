using System;

namespace SggApp.Domain.Entidades
{
    public class Gasto
    {
        // Propiedades principales
        public int Id { get; set; } // Clave primaria
        public int UsuarioId { get; set; } // Clave foránea al usuario
        public int CategoriaId { get; set; } // Clave foránea a la categoría
        public int MonedaId { get; set; } // Clave foránea a la moneda
        public decimal Monto { get; set; } // Monto del gasto
        public DateTime Fecha { get; set; } // Fecha del gasto
        public string? Descripcion { get; set; } // Descripción opcional

        // Relaciones
        public required Usuario Usuario { get; set; } // Relación con el usuario
        public required Categoria Categoria { get; set; } // Relación con la categoría
        public required Moneda Moneda { get; set; } // Relación con la moneda
    }
}