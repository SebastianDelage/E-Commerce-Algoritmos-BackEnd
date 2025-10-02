using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Usuarios.Handlers;

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
            var rows = await _usuarioRepository.GetAllAsync(UsuariosQuery.GetAll);
            return rows is null
               ? new DataResponse<IEnumerable<Usuario>>(true, 404, "Resultado no encontrado", data: rows)
               : new DataResponse<IEnumerable<Usuario>>(true, 200, "Resultado", data: rows);
        }
        [HttpGet]
        [Route("getById/{id_usuario}")]
        public async Task<BaseResponse> GetById(int id_usuario)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", id_usuario, System.Data.DbType.Int32);
            var row = await _usuarioRepository.GetByIdAsync(UsuariosQuery.GetById, parameters);
            return row is null
                ? new BaseResponse(false, 404, "Usuario no encontrado")
                : new DataResponse<Usuario>(true, 200, "Usuario encontrado", data: row);
        }

        [HttpPost]
        [Route("CrateUsuario")]
        public async Task<BaseResponse> Create([FromBody] Usuario usuario)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", usuario.Nombre);
            parameters.Add("p1", usuario.Email);
            parameters.Add("p2", usuario.Contraseña);
            parameters.Add("p3", usuario.Direccion);
            parameters.Add("p4", usuario.Telefono);
            var row = await _usuarioRepository.AddAsync(UsuariosQuery.CreateUsuario, parameters);
            return row > 0
                ? new DataResponse<Usuario>(true, 200, "Usuario creado")
                : new BaseResponse(false, 409, "El usuario ya existe");
        }

        [HttpPatch]
        [Route("UpdateUsuario/{id_usuario}")]
        public async Task<BaseResponse> UpdateUsuario(int id_usuario, [FromBody] Usuario usuario)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", usuario.Nombre);
            parameters.Add("p1", usuario.Email);
            parameters.Add("p2", usuario.Contraseña);
            parameters.Add("p3", usuario.Direccion);
            parameters.Add("p4", usuario.Telefono);
            parameters.Add("p5", id_usuario);
            var result = await _usuarioRepository.UpdateAsync(UsuariosQuery.UpdateUsuario, parameters);
            if (result <= 0)
            {
                return new BaseResponse(false, 404, "Usuario no encontrado");
            }
            else
            {
                return new DataResponse<List<Usuario>>(true, 200, "Usuario actualizado");
            }
        }
    }
}

