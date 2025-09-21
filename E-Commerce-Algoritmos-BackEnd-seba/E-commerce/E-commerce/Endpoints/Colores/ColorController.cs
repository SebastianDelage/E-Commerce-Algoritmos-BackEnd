using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Endpoints.Colores
{
    public class ColorController : ControllerBase
    {
        private readonly IRepository<Color> _colorRepository;
        public TestController(IRepository<Colores> colorRepository)
        {
            _colorRepository = colorRepository;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<BaseResponse> GetAll()
        {
            var query = Colores.GetAllColores();
            var result = await _colorRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<Colores>>(true, 200, "Resultado", data: result);
        }

        [HttpGet]
        [Route("getById/{id_color}")]
        public async Task<BaseResponse> GetById(int id_color)
        {
            var query = Colores.GetColorById(id_color);
            var result = await _colorRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<Colores>(true, 200, "Color encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Color no encontrado");
            }
        }
    }
}

