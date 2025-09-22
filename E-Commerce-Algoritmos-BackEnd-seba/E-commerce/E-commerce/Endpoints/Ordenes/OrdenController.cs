using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Ordenes
{
	public class OrdenController : ControllerBase
	{
		private readonly IRepository<Orden> _ordenRepository;
		public OrdenController(IRepository<Orden> ordenRepository)
		{
			_ordenRepository = ordenRepository;
		}
		[HttpGet]
		[Route("getAll")]
		public async Task<BaseResponse> GetAll()
		{
			var query = Orden.GetAllOrdenes();
			var result = await _ordenRepository.GetAllAsync(query);
			return new DataResponse<IEnumerable<Orden>>(true, 200, "Resultado", data: result);
		}
		[HttpGet]
		[Route("getById/{id_orden}")]
		public async Task<BaseResponse> GetById(int id_color)
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
	}
}