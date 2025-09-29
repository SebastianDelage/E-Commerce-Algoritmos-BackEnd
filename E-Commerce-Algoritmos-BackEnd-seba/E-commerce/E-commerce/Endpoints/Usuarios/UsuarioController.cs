using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Usuarios
{
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        public UsuarioController(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<BaseResponse> GetAll()
        {
            var query = Usuario.GetAllUsuarios();
            var result = await _usuarioRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<Usuario>>(true, 200, "Resultado", data: result);
        }
        [HttpGet]
        [Route("getById/{id_usuario}")]
        public async Task<BaseResponse> GetById(int id_usuario)
        {
            var query = Usuario.GetUsuarioById(id_usuario);
            var result = await _usuarioRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<Usuario>(true, 200, "Usuario encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Usuario no encontrado");
            }
        }
    }
}

