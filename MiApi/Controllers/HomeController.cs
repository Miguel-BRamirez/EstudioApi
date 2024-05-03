using MiApi.Business;
using MiApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class HomeController
    {
        private readonly IHome _home;

        public HomeController(IHome home)
        {
            _home = home;
        }

        [HttpPost]
        public async Task<HomeModel> Login(string correo, string password)
        {
            HomeModel succes = await _home.Login(correo, password);
            return succes;
        }
    }
}
