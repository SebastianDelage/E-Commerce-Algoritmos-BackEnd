using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
namespace E_commerce.Endpoints.Ordenes.Handlers;

public class GETorden
{
    public static BaseResponse GetAllOrdenes(Orden ordenes)
    {
        return new DataResponse<Orden>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: ordenes);
    }
    public static BaseResponse GetOrdenById(Orden ordenes, int id_orden)
    {
            return new DataResponse<Orden>(true, (int)HttpStatusCode.OK, "Orden encontrada", data:ordenes);

    }
}

