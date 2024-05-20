using Apptest.Shared;

namespace WebApptest.Service
{
    public interface IBaseService<T>
    {
        Task<ApiResponse> AddAsync(T model);

        Task<ApiResponse> UpdateAsync(T model);

        Task<ApiResponse> DeleteAsync(int id);
    }
}
