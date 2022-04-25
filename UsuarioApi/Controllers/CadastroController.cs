using Microsoft.AspNetCore.Mvc;
using UsuarioApi.Data.Dtos;

namespace UsuarioApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult CadastrarUsuario(CreateUsuarioDto usuarioDto)
        {

            return Ok(usuarioDto);
        }
    }
}
