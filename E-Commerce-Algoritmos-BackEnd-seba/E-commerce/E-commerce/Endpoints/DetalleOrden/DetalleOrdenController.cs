using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.DetalleOrden.Handlers;

namespace E_commerce.Endpoints.DetalleOrden
{
    [Route("[Controller]")]
    public class DetalleOrdenController : ControllerBase
    {
        private readonly IRepository<DetalleOrdenes> _detalleOrdenRepository;
        public DetalleOrdenController(IRepository<DetalleOrdenes> detalleOrdenRepository)
        {
            _detalleOrdenRepository = detalleOrdenRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<BaseResponse> GetAll()
        {
            var rows = await _detalleOrdenRepository.GetAllAsync(detalleOrdenQuery.GetAllDetalleOrden);
            return rows is null
               ? new DataResponse<IEnumerable<DetalleOrdenes>>(true, 404, "Resultado no encontrado", data: rows)
               : new DataResponse<IEnumerable<DetalleOrdenes>>(true, 200, "Resultado", data: rows);
        }
        [HttpGet]
        [Route("getById/{id_detalle_orden}")]
        public async Task<BaseResponse> GetById(int id_detalle_orden)
        {

            var row = await _detalleOrdenRepository.GetByIdAsync(detalleOrdenQuery.GetAllDetalleById(id_detalle_orden));
            return row is null
                ? new BaseResponse(false, 404, "Detalle de orden no encontrado")
                : new DataResponse<DetalleOrdenes>(true, 200, "Detalle de orden encontrado", data: row);
        }

        [HttpPost]
        [Route("CreateDetalleOrden")]
        public async Task<BaseResponse> Create([FromBody] DetalleOrdenes detalleOrden)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", detalleOrden.OrdenId);
            parameters.Add("p1", detalleOrden.PrecioUnitario);
            parameters.Add("p2", detalleOrden.Cantidad);
            parameters.Add("p3", detalleOrden.StockId);
            var row = await _detalleOrdenRepository.AddAsync(detalleOrdenQuery.CreateDetalleOrden, parameters);
            return row > 0
                ? new DataResponse<DetalleOrdenes>(true, 200, "Detalle de orden creado")
                : new BaseResponse(false, 409, "El detalle de orden ya existe");
        }

        [HttpPatch]
        [Route("updateDetalleOrden")]
        public async Task<BaseResponse> UpdateDetalleOrden(int id_detalle_orden, [FromBody] DetalleOrdenes detalleOrden)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", detalleOrden.OrdenId);
            parameters.Add("p1", detalleOrden.StockId);
            parameters.Add("p2", detalleOrden.Cantidad);
            parameters.Add("p3", detalleOrden.PrecioUnitario);
            parameters.Add("p4", id_detalle_orden);
            var row = await _detalleOrdenRepository.UpdateAsync(detalleOrdenQuery.UpdateDetalleOrden, parameters);
            return row > 0
                ? new DataResponse<DetalleOrdenes>(true, 200, "Detalle de orden actualizado")
                : new BaseResponse(false, 404, "Detalle de orden no encontrado");
        }
    }

}

