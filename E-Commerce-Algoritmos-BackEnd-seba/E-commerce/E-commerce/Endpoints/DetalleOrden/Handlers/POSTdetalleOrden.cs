using E_commerce.Repository.Models;
using E_commerce.Responses;
using System.Net;

namespace E_commerce.Endpoints.DetalleOrden.Handlers
{
    public class POSTdetalleOrden
    {
        public static BaseResponse CreateDetalleOrden(int id_detalleOrden)
        {
            return new DataResponse<List<DetalleOrdenes>>(true, (int)HttpStatusCode.OK, "Detalle de Orden creado");
        }


    }
}
