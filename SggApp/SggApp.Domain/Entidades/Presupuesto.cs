using SggApp.Domain.Entidades;

namespace SggApp.Domain.Entidades
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; } // Clave foránea al usuario
        public int CategoriaId { get; set; } // Clave foránea a la categoría
        public int MonedaId { get; set; } // Clave foránea a la moneda
        public float Limite { get; set; }
        public DateTime FechaInicio { get; set; }

        //relaciones 
        public required Usuario Usuario { get; set; }
        public required Categoria Categoria { get; set; }
        public required Moneda Moneda { get; set; } // Relación con la moneda


    }
}
