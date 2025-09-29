using E_commerce.Responses;
using E_commerce.Repository.Models;


namespace E_commerce.Endpoints.Ordenes.Handlers
{
    public class PATCHorden
    {
        public static BaseResponse UpdateOrden(Orden orden,int id)
        {
            return new DataResponse<Orden>(true, 200, "Orden actualizada", data: orden);
        }
    }
}
