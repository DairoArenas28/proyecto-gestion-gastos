using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SggApp.API.Contextos;
using SggApp.Domain.Entidades;

namespace SggApp.DAL.Repositorios
{
    public class UsuarioRepository : GenericRepository<Usuario>
    {
        private readonly SggAppContext _appContext;

        public UsuarioRepository(SggAppContext context) : base(context)
        {
            _appContext = context;
        }

        // Método específico: Obtener un usuario por su correo electrónico
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _appContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        // Método específico: Verificar si un correo electrónico ya está registrado
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _appContext.Usuarios.AnyAsync(u => u.Email == email);
        }

        // Método específico: Obtener todos los usuarios con sus gastos asociados
        public async Task<IEnumerable<Usuario>> GetAllWithGastosAsync()
        {
            return await _appContext.Usuarios
                .Include(u => u.Gastos) // Incluir los gastos relacionados
                .ToListAsync();
        }
    }
}