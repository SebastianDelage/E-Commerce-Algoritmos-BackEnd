using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Talles
{

	public class TalleController : ControllerBase
	{
		private readonly IRepository<Talles> _talleRepository;
		public TalleController(IRepository<Talles> talleRepository)
		{
			_talleRepository = talleRepository;
		}

		[HttpGet]
		[Route("getAll")]
		public async Task<BaseResponse> GetAll()
		{
			var query = Talles.GetAllTalles();
			var result = await _talleRepository.GetAllAsync(query);

			return new DataResponse<IEnumerable<Talles>>(true, 200, "Resultado", data: result);
		}

		[HttpGet]
		[Route("getById/{id_talle}")]
		public async Task<BaseResponse> GetById(int id_talle)
		{
			var query = Talles.GetTalleById(id_talle);
			var result = await _talleRepository.GetByIdAsync(query);
			if (result != null)
			{
				return new DataResponse<Talles>(true, 200, "Talle encontrado", data: result);

			}
			else
			{
				return new BaseResponse(false, 404, "Talle no encontrado");
			}
		}
	}
}