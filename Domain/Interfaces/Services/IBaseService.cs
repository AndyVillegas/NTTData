using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<T, TCreateDto, TUpdateDto> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(TCreateDto create);
        Task Update(int id, TUpdateDto update);
        Task Delete(int id);
    }
}
