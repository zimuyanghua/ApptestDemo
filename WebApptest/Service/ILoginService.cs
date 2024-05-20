using Apptest.Shared.Dtos;

namespace WebApptest.Service
{
    public interface ILoginService
    {
        Task<ApiResponse> LoginAsync(string Account, string Password);

        Task<ApiResponse> Resgiter(UserDto user);
    }
}
