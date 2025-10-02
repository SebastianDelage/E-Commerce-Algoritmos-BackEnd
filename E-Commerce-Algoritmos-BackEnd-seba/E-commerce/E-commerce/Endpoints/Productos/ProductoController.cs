using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Productos.Handlers;


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
            var rows = await _personaRepository.GetAllAsync(ProductoQuery.GetAll);
            return rows is null
               ? new DataResponse<IEnumerable<Producto>>(true, 404, "Resultado no encontrado", data: rows)
               : new DataResponse<IEnumerable<Producto>>(true, 200, "Resultado", data: rows);
        }

        [HttpGet]
        [Route("getById/{id_producto}")]
        public async Task<BaseResponse> GetById(int id_producto)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", id_producto, System.Data.DbType.Int32);
            var row = await _personaRepository.GetByIdAsync(ProductoQuery.GetById, parameters);
            return row is null
                ? new BaseResponse(false, 404, "Producto no encontrado")
                : new DataResponse<Producto>(true, 200, "Producto encontrado", data: row);
        }

        [HttpPost]
        [Route("CrateProducto")]
        public async Task<BaseResponse> Create([FromBody] Producto producto)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", producto.Nombre);
            parameters.Add("p1", producto.Descripcion);
            parameters.Add("p2", producto.Precio);
            parameters.Add("p3", producto.MarcaId);
            parameters.Add("p4", producto.GeneroId);
            var row = await _personaRepository.AddAsync(ProductoQuery.CreateProducto, parameters);
            return row > 0
                ? new DataResponse<Producto>(true, 200, "Producto creado")
                : new BaseResponse(false, 409, "El producto ya existe");
        }

        [HttpPatch]
        [Route ("UpdateProducto/{id_producto}")]
        public async Task<BaseResponse> UpdateProducto(int id_producto, [FromBody] Producto producto)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", producto.Nombre);
            parameters.Add("p1", producto.Descripcion);
            parameters.Add("p2", producto.Precio);
            parameters.Add("p3", producto.MarcaId);
            parameters.Add("p4", producto.GeneroId);
            parameters.Add("p5", id_producto);
            var row = await _personaRepository.UpdateAsync(ProductoQuery.UpdateProducto, parameters);
            return row > 0
                ? new DataResponse<Producto>(true, 200, "Producto actualizado")
                : new BaseResponse(false, 404, "Producto no encontrado");
        }
    }
}