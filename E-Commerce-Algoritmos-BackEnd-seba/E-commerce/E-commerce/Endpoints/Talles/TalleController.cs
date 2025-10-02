using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Talles.Handlers;

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
			var rows = await _talleRepository.GetAllAsync(TallesQuery.GetAll);
			return rows is null
				? new DataResponse<IEnumerable<Talle>>(true, 404, "Resultado no encontrado", data: rows)
				: new DataResponse<IEnumerable<Talle>>(true, 200, "Resultado", data: rows);
		}

		[HttpGet]
		[Route("getById/{id_talle}")]
		public async Task<BaseResponse> GetById(int id_talle)
		{
			var parameters = new Dapper.DynamicParameters();
			parameters.Add("p0", id_talle, System.Data.DbType.Int32);
			var row = await _talleRepository.GetByIdAsync(TallesQuery.GetById, parameters);
			return row is null
				? new BaseResponse(false, 404, "Talle no encontrado")
				: new DataResponse<Talle>(true, 200, "Talle encontrado", data: row);
		}

		[HttpPost]
		[Route("CrateTalle")]
		public async Task<BaseResponse> Create([FromBody] Talle talle)
		{
			var parameters = new Dapper.DynamicParameters();
			parameters.Add("p0", talle.Nombre);
			var row = await _talleRepository.AddAsync(TallesQuery.CreateTalle, parameters);
			return row > 0
				? new DataResponse<Talle>(true, 200, "Talle creado")
				: new BaseResponse(false, 409, "El talle ya existe");
        }
		[HttpPatch]
		[Route("update/{id_talle}")]
		public async Task<BaseResponse> Update(int id_talle, [FromBody] Talle talle)
		{
			var parameters = new Dapper.DynamicParameters();
			parameters.Add("p0", talle.Nombre);
			parameters.Add("p1", id_talle);
			var row = await _talleRepository.UpdateAsync(TallesQuery.UpdateTalle, parameters);
			return row > 0
				? new DataResponse<Talle>(true, 200, "Talle actualizado")
				: new BaseResponse(false, 404, "Talle no encontrado");
        }
    }
}