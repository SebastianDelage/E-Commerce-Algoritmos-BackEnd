using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using E_commerce.Endpoints.Categoria.Handlers;
using System.Net;
using Dapper;

namespace E_commerce.Endpoints.Categoria
{

    [Route("[Controller]")]
    public class CategoriaController : ControllerBase
    {
      private readonly IRepository<Categorias> _categoriaRepository;
        public CategoriaController(IRepository<Categorias> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        [Route("GetAllCategoria")]
        public async Task<BaseResponse> GetAll()
        {
            var rows = await _categoriaRepository.GetAllAsync(CategoriasQuery.GetAllCategorias); 
            return rows is null
               ? new DataResponse<IEnumerable<Categorias>>(true, (int)HttpStatusCode.NotFound, "Resultado no encontrado", data: rows)
               : new DataResponse<IEnumerable<Categorias>>(true, (int)HttpStatusCode.OK, "Resultado", data: rows);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<BaseResponse> GetById([FromQuery]int categoria_id)
        {
            var row = await _categoriaRepository.GetByIdAsync(CategoriasQuery.GetCategoriaById(categoria_id));
            return row is null
                ? new BaseResponse(false, (int)HttpStatusCode.NotFound, "Categoria no encontrada")
                : new DataResponse<Categorias>(true, (int)HttpStatusCode.OK, "Categoria encontrada", data: row);
        }


        [HttpPost]
        [Route("createCategoria")]
        public async Task<BaseResponse> CreateCategoria([FromBody] Categorias categories)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p0", categories.Nombre);
            var row = await _categoriaRepository.AddAsync(CategoriasQuery.CreateCategoria, parameters);
            return row > 0
                ? new DataResponse<Categorias>(true, (int)HttpStatusCode.OK, "Categoria creada")
                : new BaseResponse(false, (int)HttpStatusCode.Conflict, "La categoria ya existe");
        }

        [HttpPatch]
        [Route("UpadateCategoria")]
        public async Task<BaseResponse> UpdateCategoria([FromBody] Categorias categories,int id_categoria)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p0", categories.Nombre);
            parameters.Add("p1", id_categoria);
            var row = await _categoriaRepository.UpdateAsync(CategoriasQuery.UpdateCategoria);
            return row > 0
                ? new DataResponse<Categorias>(true, (int)HttpStatusCode.OK, "Categoria actualizada")
                : new BaseResponse(false, (int)HttpStatusCode.NotFound, "Categoria no encontrada");
        }

        [HttpDelete]
        [Route("DeleteCategoria")]

        public async Task<BaseResponse> DeleteCategoria([FromQuery] int categoria_id)
        {
            var row = await _categoriaRepository.DeleteAsync(CategoriasQuery.DeleteCategoriaById(categoria_id));
            return row > 0
                ? new DataResponse<Categorias>(true,(int)HttpStatusCode.OK,"Categoria eliminada")
                : new BaseResponse(false, (int)HttpStatusCode.NotFound, "Categoria no encontrada");
        }
    }

}
