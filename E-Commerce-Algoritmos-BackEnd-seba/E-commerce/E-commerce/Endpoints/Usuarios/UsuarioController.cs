using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Usuarios.Handlers;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

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
        [Route("getById")]
        public async Task<BaseResponse> GetById([FromQuery]int id_usuario)
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
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);

            parameters.Add("p0", usuario.Nombre);
            parameters.Add("p1", usuario.Email);            
            parameters.Add("p2", hashedPassword);
            parameters.Add("p3", usuario.Direccion);
            parameters.Add("p4", usuario.Telefono);
            var row = await _usuarioRepository.AddAsync(UsuariosQuery.CreateUsuario, parameters);
            return row > 0
                ? new DataResponse<Usuario>(true, 200, "Usuario creado")
                : new BaseResponse(false, 409, "El usuario ya existe");
        }

        [HttpPatch]
        [Route("UpdateUsuario")]
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


        [HttpPost]
        [Route("Login")]
        public async Task<BaseResponse> Login([FromBody] Repository.Models.LoginRequest request)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", request.Email);

            var usuario = await _usuarioRepository.GetByIdAsync(UsuariosQuery.GetUsuarioPerfilByEmail, parameters);

            if (usuario == null || usuario.Contraseña != request.Password)
            {
                return new BaseResponse(false, 401, "Credenciales inválidas");
            }

            // 1. Crear claims
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, usuario.Email),
        new Claim(ClaimTypes.Role, usuario.PerfilNombre)
    };

            // 2. Crear clave y credenciales
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("p9X$7v@Lk#3rT!zQw8mN^2sYbG0eHjUd"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3. Crear token
            var token = new JwtSecurityToken(
                issuer: "tuApp",
                audience: "tuApp",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // 4. Preparar respuesta
            var response = new
            {
                token = tokenString,
                usuario = new
                {
                    Email = usuario.Email,
                    Nombre = usuario.Nombre,
                    Perfil = usuario.PerfilNombre
                }
            };

            return new DataResponse<object>(true, 200, "Login exitoso", data: response);
        }



    }
}

