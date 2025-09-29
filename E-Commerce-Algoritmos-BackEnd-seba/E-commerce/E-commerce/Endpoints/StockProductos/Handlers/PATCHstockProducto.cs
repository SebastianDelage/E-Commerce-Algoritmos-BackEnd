using E_commerce.Repository.Models;
using E_commerce.Responses;
using System.Net;

namespace E_commerce.Endpoints.StockProductos.Handlers
{
    public class PATCHstockProducto
    {
        public static BaseResponse UpdateStockProducto(int id_stockProducto)
        {
            return new DataResponse<StockProducto>(true, (int)HttpStatusCode.OK, "Stock de Producto actualizado");
        }
    }
}
