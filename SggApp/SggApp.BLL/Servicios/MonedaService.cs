using SggApp.API.Entidades;
using SggApp.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SggApp.BLL.Servicios
{
    public class MonedaService
    {
        private readonly MonedaRepository _repo;
        public MonedaService(MonedaRepository repo) => _repo = repo;

        public async Task<IEnumerable<Moneda>> ObtenerTodosAsync() => await _repo.GetAllAsync();
        public async Task<Moneda> ObtenerPorIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AgregarAsync(Moneda moneda) => await _repo.AddAsync(moneda);
        public async Task ActualizarAsync(Moneda moneda) => _repo.Update(moneda);
        public async Task EliminarAsync(int id)
        {
            var moneda = await _repo.GetByIdAsync(id);
            if (moneda != null) _repo.Delete(moneda);
        }
    }
}
