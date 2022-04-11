using Domain.Common;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class ParametroRepository : IParametroRepository
    {
        public Parametro Get()
        {
            return new Parametro()
            {
                LimiteDiarioRetiro = Constants.LIMITE_DIARIO_RETIRO
            };
        }
    }
}
