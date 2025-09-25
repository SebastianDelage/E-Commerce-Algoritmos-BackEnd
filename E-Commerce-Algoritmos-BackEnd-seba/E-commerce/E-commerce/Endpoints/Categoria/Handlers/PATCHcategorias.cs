using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Responses;
using System.Net;

namespace E_commerce.Endpoints.Categoria.Handlers
{
    public class PATCHcategorias
    {

        public static BaseResponse UpdateCategoria(List<Categorias> categorias, int id_categoria)
        {
            Categorias? tmp = categorias.FirstOrDefault(x => x.CategoriaId == id_categoria);
            if (tmp != null)
            {
                return new DataResponse<List<Categorias>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: categorias);
            }
            else
            {
                return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Categoria no encontrada");
            }
        }
    }
}
