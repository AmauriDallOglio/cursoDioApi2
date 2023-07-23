using curso.api2.Model;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace curso.api2.Controllers
{
    [Route("api/v1/curso")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        [SwaggerResponse(statusCode: 201, description: "Sucesso no cadastro!")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizadoo!")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(Curso curso)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", curso);
        }


        [SwaggerResponse(statusCode: 201, description: "Sucesso no cadastro!")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizadoo!")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var cursos = new List<CursoViweModelOutput>(); // int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            cursos.Add(new CursoViweModelOutput()
            {
                Login = "amauri",
                Descricao = "Teste",
                Nome = "Teste"

            });
            return Ok(cursos);
        }
    }
}
