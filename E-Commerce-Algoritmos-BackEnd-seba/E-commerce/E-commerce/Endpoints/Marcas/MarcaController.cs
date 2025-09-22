using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Marcas
{
    public class MarcaController : ControllerBase
    {
        private readonly IRepository<Marca> _marcaRepository;
        public MarcaController(IRepository<Marca> marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<BaseResponse> GetAll()
        {
            var query = Marca.GetAllMarcas();
            var result = await _marcaRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<Marca>>(true, 200, "Resultado", data: result);
        }

        [HttpGet]
        [Route("getById/{id_genero}")]
        public async Task<BaseResponse> GetById(int id_marca)
        {
            var query = Marca.GetMarcaById(id_marca);
            var result = await _marcaRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<Marca>(true, 200, "Genero encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Genero no encontrado");
            }
        }
    }
}
