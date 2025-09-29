using E_commerce.Repository.Models;
using E_commerce.Responses;
using System.Net;

namespace E_commerce.Endpoints.Marcas.Handlers
{
    public class POSTmarca
    {
        public static BaseResponse CrateMarca(Marca marcas, int id_marca)
        {

          return new DataResponse<Marca>(true, (int)HttpStatusCode.Created, "Marca creada", data: marcas);
        
        }
    }
}
