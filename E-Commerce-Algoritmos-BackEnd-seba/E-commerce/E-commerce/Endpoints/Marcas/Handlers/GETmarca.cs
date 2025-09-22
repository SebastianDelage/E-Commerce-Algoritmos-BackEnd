using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
using E_commerce.Responses;

namespace E_commerce.Endpoints.Marcas.Handlers
{
    public class GETmarca
    {
        public static BaseResponse GetAllMarcas(List<Marca> marcas)
        {
            return new DataResponse<List<Marca>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: marcas);
        }
        public static BaseResponse GetMarcaById(List<Marca> marcas, int id_marca)
        {
            Marca? tmp = marcas.FirstOrDefault(x => x.MarcaId == id_marca);
            if (tmp != null)
            {
                return new DataResponse<Marca>(true, (int)HttpStatusCode.OK, "Marca encontrada", data: tmp);
            }
            else
            {
                return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Marca no encontrada");
            }
        }
    }
}