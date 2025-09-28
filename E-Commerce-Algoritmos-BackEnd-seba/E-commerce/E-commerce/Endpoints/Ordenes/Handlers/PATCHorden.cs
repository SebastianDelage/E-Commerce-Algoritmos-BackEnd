using E_commerce.Responses;
using E_commerce.Repository.Models;


namespace E_commerce.Endpoints.Ordenes.Handlers
{
    public class PATCHorden
    {
        public static BaseResponse UpdateOrden(List<Orden> orden,int id)
        {
            Orden? tmp = orden.FirstOrDefault(x => x.OrdenId == id);
            if (tmp != null)
            {
                return new DataResponse<Orden>(true, 200, "Orden actualizada", data: tmp);
            }
            else
            {
                return new BaseResponse(false, 404, "Orden no encontrada");
            }

        }
    }
}
