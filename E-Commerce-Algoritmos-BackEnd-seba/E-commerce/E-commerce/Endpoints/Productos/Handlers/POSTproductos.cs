using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;

namespace E_commerce.Endpoints.Productos.Handlers
{
    public class POSTproductos
    {
        public static BaseResponse CreateProducto()
        {
            return new DataResponse<Producto>(true, (int)HttpStatusCode.OK, "Producto creado");
        }
    }
}
