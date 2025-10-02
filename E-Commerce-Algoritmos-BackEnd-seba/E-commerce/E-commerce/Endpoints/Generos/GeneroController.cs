using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Generos.Handlers;

namespace E_commerce.Endpoints.Generos
{
    [Route("[Controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly IRepository<Repository.Models.Genero> _generoRepository;
        public GeneroController(IRepository<Repository.Models.Genero> generoRepository)
        {
            _generoRepository = generoRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<BaseResponse> GetAll()
        {
            var rows = await _generoRepository.GetAllAsync(GeneroQuerys.GetAll);
            return rows is null
               ? new DataResponse<IEnumerable<Genero>>(true, 404, "Resultado no encontrado", data: rows)
               : new DataResponse<IEnumerable<Genero>>(true, 200, "Resultado", data: rows);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<BaseResponse> GetById(int id_genero)
        {
            var row = await _generoRepository.GetByIdAsync(GeneroQuerys.GetById(id_genero);
            return row is null
                ? new BaseResponse(false, 404, "Genero no encontrado")
                : new DataResponse<Genero>(true, 200, "Genero encontrado", data: row);
        }
    }
}
