using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;

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
            var query = Color.GetAllColores();
            var result = await _colorRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<Color>>(true, 200, "Resultado", data: result);
        }

        [HttpGet]
        [Route("getById/{id_color}")]
        public async Task<BaseResponse> GetById(int id_color)
        {
            var query = Color.GetColorById(id_color);
            var result = await _colorRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<Color>(true, 200, "Color encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Color no encontrado");
            }
        }

        [HttpPatch]
        [Route("update/{id_color}")]
        public async Task<BaseResponse> UpdateColor(int id_color, [FromBody] Color colors)
        {
            var query = colors.UpdateColor();
            var result = await _colorRepository.UpdateAsync(query);

            if (result <= 0)
            {
                return new BaseResponse(false, 404, "Color no encontrado");
            }
            else
            {
                return new DataResponse<List<Color>>(true, 200, "Color actualizado");
            }

        }

        [HttpPost]
        [Route("CrateColor")]

        public async Task<BaseResponse> CreateColor([FromBody] Color colors)
        {
            var query = colors.CreateColor();
            var result = await _colorRepository.AddAsync(query);
            if (result <= 0)
            {
                return new BaseResponse(false, 409, "Color ya existe");
            }
            else
            {
                return new DataResponse<List<Color>>(true, 200, "Color creado");
            }
        }
    }
}

