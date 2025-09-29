using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Talles
{
    [Route("[Controller]")]
    public class TalleController : ControllerBase
	{
		private readonly IRepository<Talle> _talleRepository;
		public TalleController(IRepository<Talle> talleRepository)
		{
			_talleRepository = talleRepository;
		}

		[HttpGet]
		[Route("GetAll")]
		public async Task<BaseResponse> GetAll()
		{
			var query = Talle.GetAllTalles();
			var result = await _talleRepository.GetAllAsync(query);

			return new DataResponse<IEnumerable<Talle>>(true, 200, "Resultado", data: result);
		}

		[HttpGet]
		[Route("getById/{id_talle}")]
		public async Task<BaseResponse> GetById(int id_talle)
		{
			var query = Talle.GetTalleById(id_talle);
			var result = await _talleRepository.GetByIdAsync(query);
			if (result != null)
			{
				return new DataResponse<Talle>(true, 200, "Talle encontrado", data: result);

			}
			else
			{
				return new BaseResponse(false, 404, "Talle no encontrado");
			}
		}
	}
}