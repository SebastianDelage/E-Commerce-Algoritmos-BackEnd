using E_commerce.Repository.Models;
using E_commerce.Responses;

namespace E_commerce.Endpoints.Ordenes.Handlers
{
    public class POSTorden
    {
        public static BaseResponse CreateOrden(List<Orden> orden, int id)
        {
            Orden? tmp = orden.FirstOrDefault(x=> x.OrdenId == id);
            if (tmp == null)
            {
                return new DataResponse<List<Orden>>(true, 200, "Orden creada", data: orden);
            }
            else
            {
                return new BaseResponse(false, 409, "Orden ya existe");
            }
        }
    }
}
