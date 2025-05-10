using SggApp.BLL.Interfaces;
using SggApp.Domain.Entidades;
using SggApp.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SggApp.BLL.Servicios
{
    public class GastoService : IGastoService
    {
        private readonly GastoRepository _gastoRepository;
        public GastoService(GastoRepository _repo)
        {
            _gastoRepository = _repo;
        }
        public async Task<IEnumerable<Gasto>> ObtenerTodosAsync() =>
        await _gastoRepository.GetAllAsync();
        public async Task<Gasto> ObtenerPorIdAsync(int id) =>
        await _gastoRepository.GetByIdAsync(id);
        public async Task<IEnumerable<Gasto>> ObtenerPorUsuarioAsync(int usuarioId) =>
        await _gastoRepository.GetByConditionAsync(g => g.UsuarioId == usuarioId);
        public async Task AgregarAsync(Gasto gasto) =>
        await _gastoRepository.AddAsync(gasto);
        public async Task ActualizarAsync(Gasto gasto) =>
        _gastoRepository.Update(gasto);
        public async Task EliminarAsync(int id)
        {
            var gasto = await _gastoRepository.GetByIdAsync(id);
            if (gasto != null)
                _gastoRepository.Delete(gasto);
        }
    }
}
