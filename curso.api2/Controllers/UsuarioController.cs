using curso.api2.Business.Entidades;
using curso.api2.Business.Repositorio;
using curso.api2.Infra.Data;
using curso.api2.Infra.Data.Repositorio;
using curso.api2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;

namespace curso.api2.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioRepositorio iUsuarioRepositorio;


        [HttpPost]
        [Route("logar")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        //[ValidacaoModelStateCostomizado]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {
            DbContextOptionsBuilder<CursoDBContext> optionsBuilder = new DbContextOptionsBuilder<CursoDBContext>();

            string connectionString = "Server=DESKTOP-Q37347P;Database=CURSO;Trusted_Connection=True;Encrypt=False";
            //optionsBuilder.UseSqlServer("Server=DESKTOP-Q37347P;Database=CURSO;user=sa;password=admin");
            optionsBuilder.UseSqlServer(connectionString);
            

            CursoDBContext contexto = new CursoDBContext(optionsBuilder.Options);

            var migracaoPendente = contexto.Database.GetPendingMigrations();
            if (migracaoPendente.Count() > 0)
            {
                contexto.Database.Migrate();
            }



            var usuario = new Usuario();
            usuario.Login = registroViewModelInput.Login;
            usuario.Senha = registroViewModelInput.Senha;
            usuario.Email = registroViewModelInput.Email;
            contexto.Usuario.Add(usuario);
            contexto.SaveChanges();

            //iUsuarioRepositorio.Adicionar(usuario);
            //iUsuarioRepositorio.Commit();

            return Created("", registroViewModelInput);

          //  return Ok();

        }

    }
}
