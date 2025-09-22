using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
using E_commerce.Responses;

namespace E_commerce.Endpoints.Categoria.Handlers;

public class GETcategorias
{
    public static BaseResponse GetAllCategorias(List<Categorias> categories)
    {
        return new DataResponse<List<Categorias>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: categories);
    }

    public static BaseResponse GetCategoriaById(List<Categorias> categories, int id_categoria)
    {
        Categorias? tmp = categories.FirstOrDefault(x => x.CategoriaId == id_categoria);
        if (tmp != null)
        {
            return new DataResponse<List<Categorias>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: categories);
        }
        else
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Categoria no encontrada");
        }
    }
}
