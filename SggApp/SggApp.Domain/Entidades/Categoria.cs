using SggApp.Domain.Entidades;
namespace SggApp.Domain.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        /// Relaciones
        public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
        public ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();
    }
}
