using curso.api2.Business.Entidades;
using curso.api2.Business.Repositorio;

namespace curso.api2.Infra.Data.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CursoDBContext contexto;
        public UsuarioRepositorio(CursoDBContext contexto)
        {
            this.contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            contexto.Usuario.Add(usuario);
        }

        public void Commit()
        {
            contexto.SaveChanges();
        }
    }
}
