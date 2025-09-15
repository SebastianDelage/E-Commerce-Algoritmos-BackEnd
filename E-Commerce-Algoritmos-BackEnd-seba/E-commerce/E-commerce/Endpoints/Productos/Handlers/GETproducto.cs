using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;

namespace E_commerce.Endpoints.Productos.Handlers
{
    public class GETproducto
    {
        public static BaseResponse GetAllProductos(List<Producto> products)
        {
            return new DataResponse<List<Producto>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data:products);
        }
    }
}
