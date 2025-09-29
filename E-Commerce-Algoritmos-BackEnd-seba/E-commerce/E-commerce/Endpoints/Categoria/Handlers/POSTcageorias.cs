using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Categoria.Handlers
{
    public class POSTcageoroas
    {
        public static BaseResponse CreateCategoria()
        {
            return new DataResponse<Categorias>(true, (int)HttpStatusCode.Created, "Categoria creada");
        }
    }
}
