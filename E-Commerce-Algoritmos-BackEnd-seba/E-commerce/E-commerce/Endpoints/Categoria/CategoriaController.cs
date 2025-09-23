using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace E_commerce.Endpoints.Categoria
{

    public class CategoriaController : ControllerBase
    {
      private readonly IRepository<Categorias> _categoriaRepository;
        public CategoriaController(IRepository<Categorias> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<BaseResponse> GetAll()
        {
            var query = Categorias.GetAllCategorias();
            var result = await _categoriaRepository.GetAllAsync(query);
            return new DataResponse<IEnumerable<Categorias>>(true,200,"Resultado",data:result);
        }

        [HttpGet]
        [Route("getById/{id_categoria}")]
        public async Task<BaseResponse> GetById([FromQuery]int id_categoria)
        {
            var query = Categorias.GetCategoriaById(id_categoria);
            var result = await _categoriaRepository.GetByIdAsync(query);
            if (result != null)
            {
                return new DataResponse<Categorias>(true, 200, "Categoria encontrada", data: result);
            }
            else
            {
                return new BaseResponse(false, 404, "Categoria no encontrada");
            }
        }


        [HttpPost]
        [Route("createCategoria")]
        public async Task<BaseResponse> CreateCategoria([FromBody] Categorias categories)
        {
            var query = categories.CreateCategoria();
            var existingCategoria = await _categoriaRepository.AddAsync(query);

            return new BaseResponse(true, 201, "Categoria creada exitosamente");

        }
    }

}
