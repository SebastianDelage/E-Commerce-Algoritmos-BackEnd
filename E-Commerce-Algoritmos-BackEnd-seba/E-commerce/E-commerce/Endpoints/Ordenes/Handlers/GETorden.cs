using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
namespace E_commerce.Endpoints.Ordenes.Handlers

public class GETorden
{
    public static BaseResponse GetAllOrdenes(List<Orden> ordenes)
    {
        return new DataResponse<List<Orden>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: ordenes);
    }
    public static BaseResponse GetOrdenById(List<Orden> ordenes, int id_orden)
    {
        Orden? tmp = ordenes.FirstOrDefault(x => x.OrdenId == id_orden);
        if (tmp != null)
        {
            return new DataResponse<Orden>(true, (int)HttpStatusCode.OK, "Orden encontrada", data: tmp);
        }
        else
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Orden no encontrada");
        }
    }
    }
}
