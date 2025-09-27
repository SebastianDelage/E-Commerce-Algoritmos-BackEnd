using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;


namespace E_commerce.Endpoints.Marcas.Handlers
{
    public class PATCHmarca
    {
        public static BaseResponse UpdateMarca(List<Marca> marcas, int id_marca)
        {
            Marca? tmp = marcas.FirstOrDefault(x => x.MarcaId == id_marca);
            if (tmp != null)
            {
                return new DataResponse<List<Marca>>(true, (int)HttpStatusCode.OK, "Marca actualizada", data: marcas);
            }
            else
            {
                return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Marca no encontrada");
            }
        }

    }
}
