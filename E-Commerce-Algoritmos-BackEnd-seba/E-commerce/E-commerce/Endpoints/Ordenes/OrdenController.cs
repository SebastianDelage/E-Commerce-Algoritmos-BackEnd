using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Ordenes.Handlers;

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
			var rows = await _ordenRepository.GetAllAsync(OrdenesQuery.GetAllOrdenes);
			return rows is null
				? new DataResponse<IEnumerable<Orden>>(true, 404, "Resultado no encontrado", data: rows)
				: new DataResponse<IEnumerable<Orden>>(true, 200, "Resultado", data: rows);

        }
		[HttpGet]
		[Route("getById/{id_orden}")]
		public async Task<BaseResponse> GetById([FromQuery] int id_color)
		{
			var parameters = new Dapper.DynamicParameters();
			parameters.Add("p0", id_color, System.Data.DbType.Int32);
			var row = await _ordenRepository.GetByIdAsync(OrdenesQuery.GetOrdenById, parameters);
			return row is null
				? new BaseResponse(false, 404, "Orden no encontrada")
				: new DataResponse<Orden>(true, 200, "Orden encontrada", data: row);

        }

		[HttpPost]
		[Route("CreateOrden")]
		public async Task<BaseResponse> Create([FromBody] Orden orden)
		{
			var parameters = new Dapper.DynamicParameters();	
			parameters.Add("p0", orden.UsuarioId);
			parameters.Add("p1", orden.FechaOrden);
			parameters.Add("p2", orden.Estado);
			parameters.Add("p3", orden.Total);
			var row = await _ordenRepository.AddAsync(OrdenesQuery.CreateOrden, parameters);
			return row > 0
				? new DataResponse<Orden>(true, 200, "Orden creada")
				: new BaseResponse(false, 409, "La orden ya existe");
        }

		[HttpPatch]
		[Route("update/{id_orden}")]
		public async Task<BaseResponse> UpdateOrden(int id_orden, [FromBody] Orden orden)
		{
			var parameters = new Dapper.DynamicParameters();
			parameters.Add("p0", orden.UsuarioId);
			parameters.Add("p1", orden.FechaOrden);
			parameters.Add("p2", orden.Estado);
			parameters.Add("p3", orden.Total);
			parameters.Add("p4", id_orden);
			var row = await _ordenRepository.UpdateAsync(OrdenesQuery.UpdateOrden, parameters);
			return row > 0
				? new DataResponse<Orden>(true, 200, "Orden actualizada")
				: new BaseResponse(false, 409, "La orden no existe");

        }
	}
}