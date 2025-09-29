using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.Colores.Handlers
{
    public class GETcolores
    {
        public static BaseResponse GetAllColores()
        {
            return new DataResponse<Color>(true, (int)HttpStatusCode.OK, "Lista encontrada");
        }

        public static BaseResponse GetColorById(int id_color)
        {
           return new DataResponse<Color>(true, (int)HttpStatusCode.OK, "Color encontrado");
        }
    }   
}
