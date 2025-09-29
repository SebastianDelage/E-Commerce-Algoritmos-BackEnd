using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.Generos.Handlers
{
    public class GETgenero
    {
        public static BaseResponse GetAllGeneros()
        {
            return new DataResponse <Genero>(true, (int)HttpStatusCode.OK, "Lista encontrada");
        }

        public static BaseResponse GetGeneroById(Genero generos, int id_genero)
        {
           return new DataResponse<Genero>(true, (int)HttpStatusCode.OK, "Genero encontrado");
        }
    }
}


