using E_commerce.Repository.Models;
using E_commerce.Responses;

namespace E_commerce.Endpoints.DetalleOrden.Handlers
{
    public class PATCHdetalleOrden
    {
        public static BaseResponse UpdateDetalleOrden(List<DetalleOrdenes> detalleOrden,int id_detalleOrden)
        {
            DetalleOrdenes? tmp = detalleOrden.FirstOrDefault(x => x.DetalleOrdenId == id_detalleOrden);
            if (tmp != null)
            {
                return new DataResponse<DetalleOrdenes>(true, 200, "Detalle de Orden actualizado", data: tmp);
            }
            else
            {
                return new BaseResponse(false, 404, "Detalle de Orden no encontrado");
            }

        }
    }
}
