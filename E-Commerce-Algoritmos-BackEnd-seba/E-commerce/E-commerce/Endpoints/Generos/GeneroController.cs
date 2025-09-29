using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

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
            var query = Genero.GetAllGeneros();
            var result = await _generoRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<Genero>>(true, 200, "Resultado", data: result);
        }

        [HttpGet]
        [Route("getById/{id_genero}")]
        public async Task<BaseResponse> GetById(int id_genero)
        {
            var query = Genero.GetGeneroById(id_genero);
            var result = await _generoRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<Repository.Models.Genero>(true, 200, "Genero encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Genero no encontrado");
            }
        }
    }
}
