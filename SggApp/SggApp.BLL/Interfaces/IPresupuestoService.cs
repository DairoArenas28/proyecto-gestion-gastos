using SggApp.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SggApp.BLL.Interfaces
{
    public interface IPresupuestoService
    {
        Task<IEnumerable<Presupuesto>> ObtenerTodosAsync();
        Task<Presupuesto> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Presupuesto>> ObtenerPorUsuarioAsync(int usuarioId);
        Task AgregarAsync(Presupuesto presupuesto);
        Task ActualizarAsync(Presupuesto presupuesto);
        Task EliminarAsync(int id);
    }
}
