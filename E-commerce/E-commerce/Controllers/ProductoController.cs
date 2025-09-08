using E_commerce.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly IRepository<object> _repository;

        public ProductoController(IRepository<object> repository)
        {
            this._repository = repository;
        }
    }
}
