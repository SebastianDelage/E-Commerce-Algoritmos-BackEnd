using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;

namespace E_commerce.Endpoints.StockProductos.Handlers
{
    public class POSTstockProducto
    {
        public BaseResponse CrateProducto()
        {
            return new DataResponse<StockProducto>(true, (int)HttpStatusCode.OK, "Producto creado");
        }
    }
}
