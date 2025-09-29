using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;


namespace E_commerce.Endpoints.Productos
{
    [Route("[Controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IRepository<Producto> _personaRepository;

        public ProductoController(IRepository<Producto> personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<BaseResponse> GetAll()
        {
            var query = Producto.GetAllProductos();
            var result = await _personaRepository.GetAllAsync(query);

            return new DataResponse<IEnumerable<Producto>>(true, 200, "Resultado", data: result);
        }

        [HttpGet]
        [Route("getById/{id_producto}")]
        public async Task<BaseResponse> GetById(int id_producto)
        {
            var query = Producto.GetProductoById(id_producto);
            var result = await _personaRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<Producto>(true, 200, "Producto encontrado", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Producto no encontrado");
            }
        }

        [HttpPost]
        [Route("CrateProducto")]
        public async Task<BaseResponse> Create([FromBody] Producto producto)
        {
            var query = producto.CreateProducto();
            var result = await _personaRepository.AddAsync(query);
            if (result > 0)
            {
                return new DataResponse<Producto>(true, 200, "Producto creado");
            }
            else
            {
                return new BaseResponse(false, 409, "Producto ya existe");
            }
        }

        [HttpPatch]
        [Route ("UpdateProducto/{id_producto}")]
        public async Task<BaseResponse> UpdateProducto(int id_producto, [FromBody] Producto producto)
        {
            var query = producto.UpdateProducto(id_producto);
            var result = await _personaRepository.UpdateAsync(query);
            if (result <= 0)
            {
                return new BaseResponse(false, 404, "Producto no encontrado");
            }
            else
            {
                return new DataResponse<List<Producto>>(true, 200, "Producto actualizado");
            }
        }
    }
}