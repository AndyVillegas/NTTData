using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Delete(int id);
        void Delete(T domainModel);
        void Update(T domainModel);
        void Create(T domainModel);
        Task Save();
    }
}
