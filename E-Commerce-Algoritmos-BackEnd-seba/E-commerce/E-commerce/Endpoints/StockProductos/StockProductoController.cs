using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.StockProductos.Handlers;

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
            var rows = await _stockRepository.GetAllAsync(StockProductoQuery.GetAll);
            return rows is null
               ? new DataResponse<IEnumerable<StockProducto>>(true, 404, "Resultado no encontrado", data: rows)
               : new DataResponse<IEnumerable<StockProducto>>(true, 200, "Resultado", data: rows);
        }

        [HttpGet]
        [Route("getById/{id_stock}")]
        public async Task<BaseResponse> GetById(int id_stock)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", id_stock, System.Data.DbType.Int32);
            var row = await _stockRepository.GetByIdAsync(StockProductoQuery.GetById, parameters);
            return row is null
                ? new BaseResponse(false, 404, "Stock no encontrado")
                : new DataResponse<StockProducto>(true, 200, "Stock encontrado", data: row);
        }

        [HttpPatch]
        [Route("updateStock/{id_color}")]
        public async Task<BaseResponse> UpdateStock(int id_stock, [FromBody] StockProducto stock)
        {
           var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", stock.Cantidad);
            parameters.Add("p1", id_stock);
            var row = await _stockRepository.UpdateAsync(StockProductoQuery.UpdateStockProducto, parameters);
            return row > 0
                ? new DataResponse<StockProducto>(true, 200, "Stock actualizado")
                : new BaseResponse(false, 404, "Stock no encontrado");
        }
        [HttpPost]
        [Route("CreateStockProducto")]
        public async Task<BaseResponse> CreateStockProducto([FromBody] StockProducto stock)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", stock.ProductoId);
            parameters.Add("p1", stock.ColorId);
            parameters.Add("p2", stock.TallesId);
            parameters.Add("p3", stock.Cantidad);
            var row = await _stockRepository.AddAsync(StockProductoQuery.CreateStockProducto, parameters);
            return row > 0
                ? new DataResponse<StockProducto>(true, 200, "Stock creado")
                : new BaseResponse(false, 409, "El stock ya existe");
        }

    }
}