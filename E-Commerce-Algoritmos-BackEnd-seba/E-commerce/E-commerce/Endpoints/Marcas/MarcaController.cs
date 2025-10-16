using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Marcas.Handlers;

namespace E_commerce.Endpoints.Marcas
{

    [Route("[Controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IRepository<Marca> _marcaRepository;
        public MarcaController(IRepository<Marca> marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<BaseResponse> GetAll()
        {
            var rows = await _marcaRepository.GetAllAsync(MarcaQuery.GetAll);
            return rows is null
               ? new DataResponse<IEnumerable<Marca>>(true, 404, "Resultado no encontrado", data: rows)
               : new DataResponse<IEnumerable<Marca>>(true, 200, "Resultado", data: rows);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<BaseResponse> GetById(int id_marca)
        { 

            var row = await _marcaRepository.GetByIdAsync(MarcaQuery.GetMarcaById(id_marca));
            return row is null
                ? new BaseResponse(false, 404, "Marca no encontrada")
                : new DataResponse<Marca>(true, 200, "Marca encontrada", data: row);

        }

        [HttpPost]
        [Route("CrateMarca")]
        public async Task<BaseResponse> Create([FromBody] Marca marca)
        {
           var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", marca.Nombre);
            var row = await _marcaRepository.AddAsync(MarcaQuery.CreateMarca, parameters);
            return row > 0
                ? new DataResponse<Marca>(true, 200, "Marca creada")
                : new BaseResponse(false, 409, "La marca ya existe");
        }

        [HttpPatch]
        [Route("updateMarca")]
        public async Task<BaseResponse> Update(int id_marca, [FromBody] Marca marca)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", marca.Nombre);
            parameters.Add("p1", id_marca);
            var row = await _marcaRepository.UpdateAsync(MarcaQuery.UpdateMarca, parameters);
            return row > 0
                ? new DataResponse<Marca>(true, 200, "Marca actualizada")
                : new BaseResponse(false, 404, "Marca no encontrada");
        }
    }
}
