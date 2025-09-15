using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;


namespace E_commerce.Endpoints.Productos
{
    public class ProductoController : ControllerBase
    {
        private readonly IRepository<Producto> _personaRepository;

        public ProductoController(IRepository<Producto> personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<BaseResponse> GetAll()
        {
            var query = Producto.GetAllProductos();
            var result = await _personaRepository.GetAllAsync(query);

            return new DataResponse<IEnumerable<Producto>>(true,200,"Resultado",data:result);
        }
    }
}
