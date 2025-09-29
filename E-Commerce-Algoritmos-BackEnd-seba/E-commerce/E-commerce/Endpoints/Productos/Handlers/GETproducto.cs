using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.Productos.Handlers
{
    public class GETproducto
    {
        public static BaseResponse GetAllProductos()
        {
            return new DataResponse<Producto>(true, (int)HttpStatusCode.OK, "color creado");
        }

        public static BaseResponse GetProductosById(int id_producto) 
        {

           return new DataResponse<List<Producto>>(true, (int)HttpStatusCode.OK, "Lista encontrada");

        }
    }
}
