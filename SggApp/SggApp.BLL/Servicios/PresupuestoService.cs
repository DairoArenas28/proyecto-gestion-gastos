using SggApp.API.Entidades;
using SggApp.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SggApp.BLL.Servicios
{
    public class PresupuestoService
    {
        private readonly PresupuestoRepository _repo;
        public PresupuestoService(PresupuestoRepository repo) => _repo = repo;

        public async Task<IEnumerable<Presupuesto>> ObtenerTodosAsync() => await _repo.GetAllAsync();
        public async Task<Presupuesto> ObtenerPorIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task<IEnumerable<Presupuesto>> ObtenerPorUsuarioAsync(int usuarioId) =>
            await _repo.GetByConditionAsync(p => p.UsuarioId == usuarioId);

        public async Task AgregarAsync(Presupuesto presupuesto) => await _repo.AddAsync(presupuesto);
        public async Task ActualizarAsync(Presupuesto presupuesto) => _repo.Update(presupuesto);
        public async Task EliminarAsync(int id)
        {
            var presupuesto = await _repo.GetByIdAsync(id);
            if (presupuesto != null) _repo.Delete(presupuesto);
        }
    }
}
