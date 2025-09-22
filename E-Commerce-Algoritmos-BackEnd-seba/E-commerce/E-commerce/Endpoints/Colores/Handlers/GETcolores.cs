using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.Colores.Handlers
{
    public class GETcolores
{
    public static BaseResponse GetAllColores(List<Color> colors)
    {
        return new DataResponse<List<Color>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: colors);
    }

    public static BaseResponse GetColorById(List<Color> colors, int id_color)
    {
        Color? tmp = colors.FirstOrDefault(x => x.ColorId == id_color);
        if (tmp != null)
        {
            return new DataResponse<Color>(true, (int)HttpStatusCode.OK, "Color encontrado", data: tmp);
        }
        else
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Color no encontrado");
        }
    }
}
}
