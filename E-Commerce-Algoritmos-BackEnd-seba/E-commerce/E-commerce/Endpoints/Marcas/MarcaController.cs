using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Marcas
{
    public class MarcaController : ControllerBase
    {
        private readonly IRepository<Marcas> _marcaRepository;
        public MarcaController(IRepository<Marcas> marcaepository)
        {
            _marcaRepository = marcaRepository;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<BaseResponse> GetAll()
        {
            var query = Marcas.GetAllGeneros();
            var result = await _marcaRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<Marcas>>(true, 200, "Resultado", data: result);
        }

        [HttpGet]
        [Route("getById/{id_genero}")]
        public async Task<BaseResponse> GetById(int id_marca)
        {
            var query = Marcas.GetMarcaById(id_marca);
            var result = await _marcaRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<Marcas>(true, 200, "Genero encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Genero no encontrado");
            }
        }
    }
}
