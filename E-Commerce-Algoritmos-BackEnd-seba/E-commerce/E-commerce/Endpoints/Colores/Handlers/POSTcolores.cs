using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;

namespace E_commerce.Endpoints.Colores.Handlers
{
    public class POSTcolores
    {
        public static BaseResponse CreateColor(int color_id)
        {
            return new DataResponse<Color>(true, (int)HttpStatusCode.OK, "Color crado");
        }
    }
}
