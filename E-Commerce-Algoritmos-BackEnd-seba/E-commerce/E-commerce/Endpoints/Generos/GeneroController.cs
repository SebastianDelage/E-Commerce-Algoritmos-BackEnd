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
        [Route("getById")]
        public async Task<BaseResponse> GetById(int id_genero)
        {
            var row = await _generoRepository.GetByIdAsync(GeneroQuerys.GetById(id_genero));
            return row is null
                ? new BaseResponse(false, 404, "Genero no encontrado")
                : new DataResponse<Genero>(true, 200, "Genero encontrado", data: row);
        }

        [HttpGet]
        [Route("GetAllGenero")]
        public async Task<BaseResponse> GetAllGenro()
        {
            var row = await _generoRepository.GetAllAsync(GeneroQuerys.GetAll);
            return row is null
                ? new BaseResponse(false, 404, "No exitoso")
                : new DataResponse<IEnumerable<Genero>>(true, 200, "Exitoso", data: row);
        }

    }
}
