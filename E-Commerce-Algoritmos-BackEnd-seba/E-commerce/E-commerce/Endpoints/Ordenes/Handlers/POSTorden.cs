using E_commerce.Repository.Models;
using E_commerce.Responses;

namespace E_commerce.Endpoints.Ordenes.Handlers
{
    public class POSTorden
    {
        public static BaseResponse CreateOrden(Orden orden, int id)
        {
           return new DataResponse<Orden>(true, 200, "Orden creada", data: orden);
        }
    }
}
