using curso.api2.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection.Metadata.Ecma335;

namespace curso.api2.Configuracao
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDBContext>
    {
        public CursoDBContext CreateDbContext(string[] args)
        {
            //PM> Add-Migration Base-inicial
            var optionsBuilder = new DbContextOptionsBuilder<CursoDBContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=CURSO;user=sa;password=admin");
            CursoDBContext contexto = new CursoDBContext(optionsBuilder.Options);

            return contexto;
        }


    }
}
