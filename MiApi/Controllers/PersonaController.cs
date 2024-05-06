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

        [HttpGet]
        [Route("ListarPersonas")]
        public async Task<List<DetallePersona>> ListarPersonas()
        {
            List<DetallePersona> lst = await _persona.ListarPersonas();
            return lst;
        }

        [HttpPut]
        [Route("EditarPersona")]
        public async Task<List<DetallePersona>> EditarPersona(DetallePersona persona)
        {
            List<DetallePersona> lst = await _persona.EditarPersona(persona);
            return lst;
        }

        [HttpDelete]
        [Route("EliminarPersona")]
        public async Task<bool> EliminarPersona(int id)
        {
            bool rspt = await _persona.EliminarPersona(id);
            return rspt;
        }
    }
}
