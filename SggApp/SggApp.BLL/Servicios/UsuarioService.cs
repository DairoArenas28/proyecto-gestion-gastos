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
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _repo;
        public UsuarioService(UsuarioRepository repo) => _repo = repo;

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync() => await _repo.GetAllAsync();
        public async Task<Usuario> ObtenerPorIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task<Usuario> ObtenerPorEmailAsync(string email) =>
            (await _repo.GetByConditionAsync(u => u.Email == email)).FirstOrDefault();

        public async Task AgregarAsync(Usuario usuario) => await _repo.AddAsync(usuario);
        public async Task ActualizarAsync(Usuario usuario) => _repo.Update(usuario);
        public async Task EliminarAsync(int id)
        {
            var usuario = await _repo.GetByIdAsync(id);
            if (usuario != null) _repo.Delete(usuario);
        }
    }
}
