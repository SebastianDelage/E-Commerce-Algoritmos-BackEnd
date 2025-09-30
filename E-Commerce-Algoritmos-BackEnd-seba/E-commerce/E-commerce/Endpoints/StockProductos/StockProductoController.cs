using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.StockProductos
{
    [Route("[Controller]")]
    public class StockProductoController : ControllerBase
    {
        private readonly IRepository<StockProducto> _stockRepository;
        public StockProductoController(IRepository<StockProducto> stockRepository)
        {
            _stockRepository = stockRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<BaseResponse> GetAll()
        {
            var query = Color.GetAllColores();
            var result = await _stockRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<StockProducto>>(true, 200, "Resultado", data: result);
        }
        [HttpGet]
        [Route("getById/{id_color}")]
        public async Task<BaseResponse> GetById(int id_color)
        {
            var query = Color.GetColorById(id_color);
            var result = await _stockRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<StockProducto>(true, 200, "Color encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Color no encontrado");
            }
        }

        [HttpPatch]
        [Route("updateStock/{id_color}")]
        public async Task<BaseResponse> UpdateStock(int id_stock, [FromBody] StockProducto stock)
        {
            var query = stock.UpdateStockProducto(id_stock);
            var result = await _stockRepository.UpdateAsync(query);
            if (result <= 0)
            {
                return new BaseResponse(false, 404, "Color no encontrado");
            }
            else
            {
                return new DataResponse<List<StockProducto>>(true, 200, "Color actualizado");
            }
        }

    }
}