using E_commerce.Repository.Models;
using E_commerce.Responses;

namespace E_commerce.Endpoints.DetalleOrden.Handlers
{
    public class PATCHdetalleOrden
    {
        public static BaseResponse UpdateDetalleOrden(int id_detalleOrden)
        {

                return new DataResponse<DetalleOrdenes>(true, 200, "Detalle de Orden actualizado");

        }
    }
}
