using DesafioConfitec.Services.Dtos;
using DesafioConfitec.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioConfitec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _usuarioService.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _usuarioService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDto obj)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    return Ok(await _usuarioService.AddAsync(obj));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(new BadRequestObjectResult(ModelState));
        }

        // PUT api/<UsuariosController>
        [HttpPut]
        public async Task<IActionResult> Put(UsuarioDto obj)
        {
            try
            {
                return Ok(await _usuarioService.EditAsync(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _usuarioService.DeleteAsync(id);
                return Ok("Registro excluído");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}