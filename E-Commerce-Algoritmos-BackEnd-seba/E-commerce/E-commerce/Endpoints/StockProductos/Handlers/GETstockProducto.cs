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
            return new DataResponse<List<StockProducto>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: stockProductos);
        }

        static public BaseResponse GetStockProductoById(List<StockProducto> stockProductos, int id_stockProducto)
        {
            StockProducto? tmp = stockProductos.FirstOrDefault(x => x.StockProductoId == id_stockProducto);
            if (tmp != null)
            {
                return new DataResponse<StockProducto>(true, (int)HttpStatusCode.OK, "StockProducto encontrado", data: tmp);
            }
            else
            {
                return new BaseResponse(false, (int)HttpStatusCode.NotFound, "StockProducto no encontrado");
            }
        }
    }
}

