
using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
namespace E_commerce.Endpoints.DetalleOrden.Handlers
{

    public class GETdetalleOrden
{
    public static BaseResponse GetAllDetalleOrden(List<DetalleOrdenes> detalleOrdens)
    {
        return new DataResponse<List<DetalleOrdenes>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: detalleOrdens);
    }

    public static BaseResponse GetDetalleOrdenById(List<DetalleOrdenes> detalleOrdens, int id_detalleOrden)
    {
        DetalleOrdenes? tmp = detalleOrdens.FirstOrDefault(x => x.DetalleOrdenId == id_detalleOrden);
        if (tmp != null)
        {
            return new DataResponse<DetalleOrdenes>(true, (int)HttpStatusCode.OK, "Detalle de Orden encontrado", data: tmp);
        }
        else
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Detalle de Orden no encontrado");
        }
    }
    }
}
