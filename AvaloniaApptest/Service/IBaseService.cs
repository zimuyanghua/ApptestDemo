using Apptest.Shared;
using System.Threading.Tasks;

namespace AvaloniaApptest.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<ApiResponse<TEntity>> AddAsync(TEntity entity);

        Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity);

        Task<ApiResponse> DeleteAsync(int id);
    }
}
