using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Productos.Handlers;
using System.Net;


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
        [Route("getById")]
        public async Task<BaseResponse> GetById([FromQuery] int id_producto)
        {
   
            var row = await _personaRepository.GetByIdAsync(ProductoQuery.GetAllById(id_producto));
            return row is null
                ? new BaseResponse(false, 404, "Producto no encontrado")
                : new DataResponse<Producto>(true, 200, "Producto encontrado", data: row);
        }

        [HttpGet]
        [Route("GetByCategoria")]
        public async Task<BaseResponse> GetByCategoria([FromQuery]int categoriaId)
        {

            var row = await _personaRepository.GetByIdAsync(ProductoQuery.GetAllById(categoriaId));
            return row is null
                ? new BaseResponse(false, (int)HttpStatusCode.NotFound, "Producto no encontrado")
                : new DataResponse<Producto>(true, (int)HttpStatusCode.OK, "Producto encontrado", data: row);
        }

        [HttpGet]
        [Route("GetProductoPromocion")]
        public async Task<BaseResponse> GetProductoPromocion(int estado)
        {
            var row = await _personaRepository.GetListAsync(ProductoQuery.GetProductoPromocion(estado));
            return row is null
                ? new BaseResponse(false, (int)HttpStatusCode.NotFound, "Producto no encontrado")
                : new DataResponse<List<Producto>>(true, (int)HttpStatusCode.OK, "Producto encontrado", data: row);
        }

        [HttpGet]
        [Route("GetProductoByGenero")]
        public async Task<BaseResponse> GetProductoByGenero([FromQuery] int genero_id)
        {
            var rows = await _personaRepository.GetListAsync(ProductoQuery.GetProductoByGenero(genero_id));

            return rows == null || !rows.Any()
                ? new BaseResponse(false, 404, "Productos no encontrados")
                : new DataResponse<List<Producto>>(true, 200, "Productos encontrados", data: rows);
        }
        [HttpPost]
        [Route("CrateProducto")]
        public async Task<BaseResponse> Create([FromBody] Producto producto)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("p0", producto.Nombre);
            parameters.Add("p1", producto.Descripcion);
            parameters.Add("p2", producto.Precio);
            parameters.Add("p3", producto.marca_id);
            parameters.Add("p4", producto.genero_id);
            var row = await _personaRepository.AddAsync(ProductoQuery.CreateProducto, parameters);
            return row > 0
                ? new DataResponse<Producto>(true, 200, "Producto creado")
                : new BaseResponse(false, 409, "El producto ya existe");
        }

        [HttpPatch]
        [Route("UpdateProducto")]
        public async Task<BaseResponse> UpdateProducto(int producto_id, [FromBody] Producto producto)
        {
            var parameters = new Dapper.DynamicParameters();
            parameters.Add("nombre", producto.Nombre);
            parameters.Add("descripcion", producto.Descripcion);
            parameters.Add("precio", producto.Precio);
            parameters.Add("marca_id", producto.marca_id);
            parameters.Add("genero_id", producto.genero_id);
            parameters.Add("categoria_id", producto.categoria_id);
            parameters.Add("producto_id", producto_id);

            var row = await _personaRepository.UpdateAsync(ProductoQuery.UpdateProducto, parameters);

            return row > 0
                ? new DataResponse<Producto>(true, 200, "Producto actualizado", producto)
                : new BaseResponse(false, 404, "Producto no encontrado");
        }

    }
}