using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Responses;
using System.Net;

namespace E_commerce.Endpoints.Categoria.Handlers
{
    public class PATCHcategorias
    {

        public static BaseResponse UpdateCategoria(int id_categoria)
        {
            return new DataResponse<Categorias>(true, (int)HttpStatusCode.OK, "color creado");
        }
    }
}
