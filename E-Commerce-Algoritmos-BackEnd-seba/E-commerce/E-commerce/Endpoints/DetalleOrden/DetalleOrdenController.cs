using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.DetalleOrden
{ 
    public class DetalleOrdenController : ControllerBase
    {
        private readonly IRepository<DetalleOrden> _detalleOrdenRepository;
        public DetalleOrdenController(IRepository<DetalleOrden> detalleOrdenRepository)
        {
            _detalleOrdenRepository = detalleOrdenRepository;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<BaseResponse> GetAll()
        {
            var query = DetalleOrden.GetAllDetalleOrdens();
            var result = await _detalleOrdenRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<DetalleOrden>>(true, 200, "Resultado", data: result);
        }
        [HttpGet]
        [Route("getById/{id_detalle_orden}")]
        public async Task<BaseResponse> GetById(int id_detalle_orden)
        {
            var query = DetalleOrden.GetDetalleOrdenById(id_detalle_orden);
            var result = await _detalleOrdenRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<DetalleOrden>(true, 200, "Detalle de orden encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Detalle de orden no encontrado");
            }
        }
    }

}

