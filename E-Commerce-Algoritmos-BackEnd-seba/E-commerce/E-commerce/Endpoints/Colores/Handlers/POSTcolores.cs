using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;

namespace E_commerce.Endpoints.Colores.Handlers
{
    public class POSTcolores
    {
        public static BaseResponse CreateColor(List<Color> colors, int color_id, string nombre, string codigo)
        {
            Color? tmp = colors.FirstOrDefault(x => x.ColorId == color_id);
            if (tmp != null)
            {
                return new DataResponse<List<Color>>(false, (int)HttpStatusCode.OK, "Color crado",data:colors);
            }
            else
            {
                return new BaseResponse(false, (int)HttpStatusCode.Conflict, "Color ya existe");
            }
        }
    }
}
