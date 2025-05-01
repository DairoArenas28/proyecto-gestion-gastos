using SggApp.API.Entidades;
using SggApp.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SggApp.BLL.Servicios
{
    public class CategoriaService
    {
        private readonly CategoriaRepository _repo;
        public CategoriaService(CategoriaRepository repo) => _repo = repo;

        public async Task<IEnumerable<Categoria>> ObtenerTodosAsync() => await _repo.GetAllAsync();
        public async Task<Categoria> ObtenerPorIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task AgregarAsync(Categoria categoria) => await _repo.AddAsync(categoria);
        public async Task ActualizarAsync(Categoria categoria) => _repo.Update(categoria);
        public async Task EliminarAsync(int id)
        {
            var categoria = await _repo.GetByIdAsync(id);
            if (categoria != null) _repo.Delete(categoria);
        }
    }
}
