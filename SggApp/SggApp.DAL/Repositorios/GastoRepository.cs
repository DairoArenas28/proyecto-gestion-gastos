using Microsoft.EntityFrameworkCore;
using SggApp.API.Contextos;
using SggApp.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SggApp.DAL.Repositorios
{
    public class GastoRepository : GenericRepository<Gasto> 
    {
        private readonly SggAppContext _appContext;

        public GastoRepository( SggAppContext context ) : base( context )
        {
            _appContext = context;
        }
    }
}
