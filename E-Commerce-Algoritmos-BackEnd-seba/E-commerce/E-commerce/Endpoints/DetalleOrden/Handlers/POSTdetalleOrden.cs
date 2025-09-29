using E_commerce.Repository.Models;
using E_commerce.Responses;
using System.Net;

namespace E_commerce.Endpoints.DetalleOrden.Handlers
{
    public class POSTdetalleOrden
    {
        public static BaseResponse CreateDetalleOrden(List<DetalleOrdenes> detalleOrden, int id_detalleOrden)
        {
            DetalleOrdenes? tmp = detalleOrden.FirstOrDefault(x => x.DetalleOrdenId == id_detalleOrden);
            if (tmp != null)
            {
                return new DataResponse<DetalleOrdenes>(false, (int)HttpStatusCode.BadRequest, "Detalle de Orden ya existe", data: tmp);
            }
            else

                return new DataResponse<List<DetalleOrdenes>>(true, (int)HttpStatusCode.OK, "Detalle de Orden creado", data: detalleOrden);
        }


    }
}
