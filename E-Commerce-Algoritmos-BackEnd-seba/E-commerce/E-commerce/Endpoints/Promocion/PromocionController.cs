using E_commerce.Endpoints.Promocio.Handlers;
using E_commerce.Repository.Interfaces;
using E_commerce.Repository.Models;
using E_commerce.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_commerce.Endpoints.Promocion
{
    [Route("[Controller]")]
    public class PromocionController:ControllerBase
    {
        private readonly IRepository<Promociones> _promocionRepository;
        
        public PromocionController(IRepository<Promociones> promocionRepository)
        {
            _promocionRepository = promocionRepository;
        }

        [HttpGet]
        public async Task<BaseResponse> GetAllPromociones()
        {
            var rows = await _promocionRepository.GetAllAsync(PromocionesQuery.GetAllPromociones);
            return rows is null
                ? new DataResponse<IEnumerable<Promociones>>(true, (int)HttpStatusCode.NotFound, "No se econtro",data:rows)
                : new DataResponse<IEnumerable<Promociones>>(true,(int)HttpStatusCode.OK,"econtrado",data:rows);
        }
    }
}
