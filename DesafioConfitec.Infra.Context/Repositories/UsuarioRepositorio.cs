using DesafioConfitec.Contracts;
using DesafioConfitec.Domain.Entities;
using DesafioConfitec.Infra.Data.Context;

namespace DesafioConfitec.Infra.Data.Repositories
{
    public class UsuarioRepositorio : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositorio(DataContext dbContext) : base(dbContext)
        {
        }
    }
}