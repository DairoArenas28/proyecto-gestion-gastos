using SggApp.API.Contextos;
using SggApp.API.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SggApp.DAL.Repositorios
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        private readonly SggAppContext _appContext;
        public CategoriaRepository(SggAppContext context) : base(context) { 
            _appContext = context;
        }
    }
}
