using Apptest.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApptest.Service;

namespace WebApptest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService service;

        public LoginController(ILoginService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ApiResponse> Login([FromBody] UserDto param) =>
            await service.LoginAsync(param.Account, param.PassWord);

        [HttpPost]
        public async Task<ApiResponse> Resgiter([FromBody] UserDto param) =>
            await service.Resgiter(param);
    }
}
