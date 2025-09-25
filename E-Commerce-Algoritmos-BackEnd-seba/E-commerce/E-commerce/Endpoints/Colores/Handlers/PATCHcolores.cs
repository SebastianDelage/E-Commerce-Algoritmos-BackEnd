using E_commerce.Repository.Models;
using E_commerce.Responses;

namespace E_commerce.Endpoints.Colores.Handlers
{
    public class PATCHcolores
    {
        public static BaseResponse UpdateColores(List<Color> colors, int id_color)
        {
            Color? tmp = colors.FirstOrDefault(x => x.ColorId == id_color);
            if (tmp != null)
            {
                return new DataResponse<List<Color>>(true, (int)System.Net.HttpStatusCode.OK, "Lista encontrada", data: colors);
            }
            else
            {
                return new BaseResponse(false, (int)System.Net.HttpStatusCode.NotFound, "Color no encontrado");

            }
        }


    }
}
 