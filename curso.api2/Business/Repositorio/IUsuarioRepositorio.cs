using curso.api2.Business.Entidades;

namespace curso.api2.Business.Repositorio
{
    public interface IUsuarioRepositorio
    {
        public void Adicionar(Usuario usuario);
        void Commit();
    }
}
