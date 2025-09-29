using E_commerce.Responses;
using E_commerce.Repository.Models;

using E_commerce.Endpoints.Productos.Request;

using System.Net;
namespace E_commerce.Endpoints.Productos.Handlers
{
    public class PATCHproductos
    {
        public static BaseResponse EditOnePersona( int id_producto)
        {
            return new DataResponse<EditOneProducto>(true, (int)HttpStatusCode.OK, "Producto modificado");
        }
    }
}