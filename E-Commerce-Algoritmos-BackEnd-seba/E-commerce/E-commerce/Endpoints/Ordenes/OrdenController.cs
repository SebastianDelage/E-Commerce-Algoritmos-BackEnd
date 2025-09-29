using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Ordenes
{
    [Route("[Controller]")]
    public class OrdenController : ControllerBase
	{
		private readonly IRepository<Orden> _ordenRepository;
		public OrdenController(IRepository<Orden> ordenRepository)
		{
			_ordenRepository = ordenRepository;
		}
		[HttpGet]
		[Route("GetAll")]
		public async Task<BaseResponse> GetAll()
		{
			var query = Orden.GetAllOrdenes();
			var result = await _ordenRepository.GetAllAsync(query);
			return new DataResponse<IEnumerable<Orden>>(true, 200, "Resultado", data: result);
		}
		[HttpGet]
		[Route("getById/{id_orden}")]
		public async Task<BaseResponse> GetById([FromQuery]int id_color)
		{
			var query = Orden.GetOrdenById(id_color);
			var result = await _ordenRepository.GetByIdAsync(query);
			if (result != null)
			{
				return new DataResponse<Orden>(true, 200, "Orden encontrada", data: result);
			}
			else
			{
				return new BaseResponse(false, 404, "Orden no encontrada");
			}

		}

		[HttpPost]
		[Route("CreateOrden")]
		public async Task<BaseResponse> Create([FromBody] Orden orden)
		{
			var query = orden.InsertOrden();
			var result =await _ordenRepository.AddAsync(query);
			if (result != null)
			{
				return new DataResponse<Orden>(true, 200, "Orden creada");
			}
			else
			{
				return new BaseResponse(false, 409, "Orden ya existe");
			}
        }
    }
}