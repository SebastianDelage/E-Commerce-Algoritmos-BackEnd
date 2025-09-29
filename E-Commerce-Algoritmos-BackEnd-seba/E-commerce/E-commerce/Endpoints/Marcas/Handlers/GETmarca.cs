using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
using E_commerce.Responses;

namespace E_commerce.Endpoints.Marcas.Handlers
{
    public class GETmarca
    {
        public static BaseResponse GetAllMarcas(Marca marcas)
        {
            return new DataResponse<Marca>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: marcas);
        }

        public static BaseResponse GetMarcaById(Marca marcas, int id_marca)
        {

            return new DataResponse<Marca>(true, (int)HttpStatusCode.OK, "Marca encontrada", data:marcas);

        }
    }
}