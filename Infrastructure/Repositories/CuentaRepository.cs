using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class CuentaRepository : BaseRepository<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(NTTDATAContext context) : base(context)
        {
        }
        protected override IQueryable<Cuenta> GetQueryable()
        {
            return base.GetQueryable().Include(e => e.Cliente);
        }
    }
}
