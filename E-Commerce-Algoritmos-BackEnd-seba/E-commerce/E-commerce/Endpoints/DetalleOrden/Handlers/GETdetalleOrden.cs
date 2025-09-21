
using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
namespace E_commerce.Endpoints.DetalleOrden.Handlers
{

    public class GETdetalleOrden
{
    public static BaseResponse GetAllDetalleOrden(List<DetalleOrden> detalleOrdens)
    {
        return new DataResponse<List<DetalleOrden>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: detalleOrdens);
    }

    public static BaseResponse GetDetalleOrdenById(List<DetalleOrden> detalleOrdens, int id_detalleOrden)
    {
        DetalleOrden? tmp = detalleOrdens.FirstOrDefault(x => x.DetalleOrdenId == id_detalleOrden);
        if (tmp != null)
        {
            return new DataResponse<DetalleOrden>(true, (int)HttpStatusCode.OK, "Detalle de Orden encontrado", data: tmp);
        }
        else
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Detalle de Orden no encontrado");
        }
    }
    }
}
