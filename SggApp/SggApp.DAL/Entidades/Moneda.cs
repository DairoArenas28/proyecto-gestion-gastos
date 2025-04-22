using SggApp.DAL.Entidades;

namespace SggApp.API.Entidades
{
    public class Moneda
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Simbolo { get; set; }

        public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
        public ICollection<Presupuesto> Presupuestos { get; set; } = new List<Presupuesto>();

    }
}
