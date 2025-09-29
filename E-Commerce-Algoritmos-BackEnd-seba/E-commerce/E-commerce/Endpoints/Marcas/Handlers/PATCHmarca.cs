using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;


namespace E_commerce.Endpoints.Marcas.Handlers
{
    public class PATCHmarca
    {
        public static BaseResponse UpdateMarca(Marca marcas, int id_marca)
        {
            return new DataResponse<Marca>(true, (int)HttpStatusCode.OK, "Marca actualizada", data: marcas);
        }

    }
}
