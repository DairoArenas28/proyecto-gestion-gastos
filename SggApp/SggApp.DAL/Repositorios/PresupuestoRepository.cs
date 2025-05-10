using SggApp.API.Contextos;
using SggApp.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SggApp.DAL.Repositorios
{
    public class PresupuestoRepository : GenericRepository<Presupuesto>
    {
        private readonly SggAppContext _appContext;
        public PresupuestoRepository(SggAppContext context) : base(context) {
            _appContext = context;
        }
    }
}
