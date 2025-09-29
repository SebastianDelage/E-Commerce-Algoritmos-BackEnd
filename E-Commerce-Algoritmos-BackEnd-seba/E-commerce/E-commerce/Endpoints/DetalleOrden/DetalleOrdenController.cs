using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

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
            var query = DetalleOrdenes.GetAllDetalleOrden();
            var result = await _detalleOrdenRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<DetalleOrdenes>>(true, 200, "Resultado", data: result);
        }
        [HttpGet]
        [Route("getById/{id_detalle_orden}")]
        public async Task<BaseResponse> GetById(int id_detalle_orden)
        {
            var query = DetalleOrdenes.GetDetalleOrdenById(id_detalle_orden);
            var result = await _detalleOrdenRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<DetalleOrdenes>(true, 200, "Detalle de orden encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Detalle de orden no encontrado");
            }
        }
    }

}

