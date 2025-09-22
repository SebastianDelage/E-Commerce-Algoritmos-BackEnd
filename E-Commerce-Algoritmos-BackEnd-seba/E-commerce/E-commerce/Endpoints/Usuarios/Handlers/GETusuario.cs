using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.Usuarios.Handlers
{
    public class GETusuairio
    {
       static public BaseResponse GetAllUsuarios(List<Usuario> usuarios)
        {
            return new DataResponse<List<Usuario>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: usuarios);
        }

        static public BaseResponse GetUsuarioById(List<Usuario> usuarios, int id_usuario)
        {
            Usuario? tmp = usuarios.FirstOrDefault(x => x.UsuarioId == id_usuario);
            if (tmp != null)
            {
                return new DataResponse<Usuario>(true, (int)HttpStatusCode.OK, "Usuario encontrado", data: tmp);
            }
            else
            {
                return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Usuario no encontrado");
            }
        }
    }

}
