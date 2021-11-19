using AutoMapper;
using DesafioConfitec.Contracts;
using DesafioConfitec.Domain.Entities;
using DesafioConfitec.Services.Dtos;
using DesafioConfitec.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioConfitec.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAsync()
        {
            var listaUsuarios = await _usuarioRepository.GetAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(listaUsuarios);
        }

        public async Task<UsuarioDto> GetAsync(int id)
        {
            var usuario = await _usuarioRepository.GetAsync(id);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> AddAsync(UsuarioDto obj)
        {
            var usuario = _mapper.Map<Usuario>(obj);
            await _usuarioRepository.AddAsync(usuario);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> EditAsync(UsuarioDto obj)
        {
            var usuario = _mapper.Map<Usuario>(obj);
            await _usuarioRepository.EditAsync(usuario);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}