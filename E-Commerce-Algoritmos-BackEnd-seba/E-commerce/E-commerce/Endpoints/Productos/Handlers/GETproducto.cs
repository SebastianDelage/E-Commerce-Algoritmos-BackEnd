using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.Productos.Handlers
{
    public class GETproducto
    {
        public static BaseResponse GetAllProductos(List<Producto> products)
        {
            return new DataResponse<List<Producto>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data:products);
        }

        public static BaseResponse GetProductosById(List<Producto>products,int id_producto) 
        {
            Producto? tmp = products.FirstOrDefault(x => x.ProductoId == id_producto);
            if (tmp != null)
            {
                return new DataResponse<List<Producto>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: products);
            }
            else
            {
                return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Producto no encontrado");
            }
        }
    }
}
