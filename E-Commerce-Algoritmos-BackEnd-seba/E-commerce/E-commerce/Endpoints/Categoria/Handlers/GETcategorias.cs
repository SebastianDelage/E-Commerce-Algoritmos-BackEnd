using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
using E_commerce.Responses;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Categoria.Handlers;

public class GETcategorias
{

    public static BaseResponse GetAllCategorias()
    {
        return new DataResponse<Categorias>(true, (int)HttpStatusCode.OK, "Lista encontrada");
    }

    public static BaseResponse GetCategoriaById(int id_categoria)
    {
        return new DataResponse<Categorias>(true, (int)HttpStatusCode.OK, "Lista encontrada");
    }
}
