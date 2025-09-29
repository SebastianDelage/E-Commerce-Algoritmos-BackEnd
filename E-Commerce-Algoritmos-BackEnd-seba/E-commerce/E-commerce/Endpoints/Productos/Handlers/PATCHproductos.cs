using E_commerce.Responses;
using E_commerce.Repository.Models;

using E_commerce.Endpoints.Productos.Request;

using System.Net;
namespace E_commerce.Endpoints.Productos.Handlers
{
    public class PATCHproductos
    {
        public static BaseResponse EditOnePersona(List<EditOneProducto> product, int id_producto)
        {
            EditOneProducto? tmp = product.FirstOrDefault(x => x.ProductoId == id_producto);

            if (tmp == null)
            {
                return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Producto no encontrado");
            }
            else
            {

                return new DataResponse<EditOneProducto>(true, (int)HttpStatusCode.OK, "Producto modificado", data: tmp);
            }
        }
    }
}