using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.Colores.Handlers
{
    public class GETcolores
{
    public static BaseResponse GetAllColores(List<Colores> colors)
    {
        return new DataResponse<List<Colores>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: colors);
    }

    public static BaseResponse GetColorById(List<Colores> colors, int id_color)
    {
        Colores? tmp = colors.FirstOrDefault(x => x.ColorId == id_color);
        if (tmp != null)
        {
            return new DataResponse<Colores>(true, (int)HttpStatusCode.OK, "Color encontrado", data: tmp);
        }
        else
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Color no encontrado");
        }
    }
}
}
