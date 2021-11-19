using DesafioConfitec.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioConfitec.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAsync();

        Task<UsuarioDto> GetAsync(int id);

        Task<UsuarioDto> AddAsync(UsuarioDto obj);

        Task<UsuarioDto> EditAsync(UsuarioDto obj);

        Task DeleteAsync(int id);
    }
}