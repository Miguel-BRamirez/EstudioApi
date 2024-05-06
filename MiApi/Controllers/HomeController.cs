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
        public async Task<List<DetallePersona>> Login(string correo, string password)
        {
            List<DetallePersona> succes = await _home.Login(correo, password);
            return succes;
        }
    }
}
