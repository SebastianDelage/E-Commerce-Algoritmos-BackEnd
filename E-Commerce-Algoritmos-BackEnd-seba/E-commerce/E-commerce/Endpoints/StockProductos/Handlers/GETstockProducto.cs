using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.StockProductos.Handlers 
{

    public class GETstockProducto
    {
         static public BaseResponse GetAllStockProductos(List<StockProducto> stockProductos)
        {
            return new DataResponse<StockProducto>(true, (int)HttpStatusCode.OK, "Lista encontrada");
        }

        static public BaseResponse GetStockProductoById(int id_stockProducto)
        {
            return new DataResponse<StockProducto>(true, (int)HttpStatusCode.OK, "StockProducto encontrado");  
        }
    }
}

