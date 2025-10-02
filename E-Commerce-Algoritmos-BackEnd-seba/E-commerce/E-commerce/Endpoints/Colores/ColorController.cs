using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Colores.Handlers;
using System.Net;

namespace E_commerce.Endpoints.Colores
{
    [Route("[Controller]")]
    public class ColorController : ControllerBase
    {
        private readonly IRepository<Color> _colorRepository;
        public ColorController(IRepository<Color> colorRepository)
        {
            _colorRepository = colorRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<BaseResponse> GetAll()
        {
            var rows = await _colorRepository.GetAllAsync(ColoresQuery.GetAllColores);
            return rows is null
                ? new DataResponse<IEnumerable<Color>>(true, (int)HttpStatusCode.NotFound, "No se encontro", data: rows)
                : new DataResponse<IEnumerable<Color>>(true, (int)HttpStatusCode.OK, "Resultado", data: rows);

        }

        [HttpGet]
        [Route("getById/{id_color}")]
        public async Task<BaseResponse> GetById([FromQuery]int id_color)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", id_color, System.Data.DbType.Int32);
            var row = await _colorRepository.GetByIdAsync(ColoresQuery.GetColorById, parameters);
            return row is null
                ? new BaseResponse(false, (int)HttpStatusCode.NotFound, "Color no encontrado")
                : new DataResponse<Color>(true, (int)HttpStatusCode.OK, "Color encontrado", data: row);
        }

        [HttpPatch]
        [Route("update/{id_color}")]
        public async Task<BaseResponse> UpdateColor(int id_color, [FromBody] Color colors)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", colors.Nombre);
            parameters.Add("p1", colors.Codigo);
            parameters.Add("p2", id_color);
            var row = await _colorRepository.UpdateAsync(ColoresQuery.UpdateColor, parameters);
            return row > 0
                ? new DataResponse<Color>(true, (int)HttpStatusCode.OK, "Color actualizado")
                : new BaseResponse(false, (int)HttpStatusCode.NotFound, "Color no encontrado"); 

        }

        [HttpPost]
        [Route("CrateColor")]

        public async Task<BaseResponse> CreateColor([FromBody] Color colors)
        {
           var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", colors.Nombre);
            parameters.Add("p1", colors.Codigo);
            var row = await _colorRepository.AddAsync(ColoresQuery.CreateColor, parameters);
            return row > 0
                ? new DataResponse<Color>(true, (int)HttpStatusCode.OK, "Color creado")
                : new BaseResponse(false, (int)HttpStatusCode.Conflict, "El color ya existe");
        }
    }
}

