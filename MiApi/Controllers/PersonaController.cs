using MiApi.Business;
using MiApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/persona")]
    public class PersonaController
    {
        private readonly IPersona _persona;

        public PersonaController(IPersona persona)
        {
            _persona = persona;
        }

        [HttpPost]
        [Route("InsertarPersona")]
        public async Task<ActionResult<bool>> Add(PersonaModel persona)
        {
            bool succes = await _persona.InsertarPersona(persona);
            return succes;
        }
    }
}
