using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;

namespace E_commerce.Endpoints.Categoria.Handlers
{
    public class POSTcageoroas
    {
        public static BaseResponse CreateCategoria(List<Categorias> catgories ,int cagoira_id,string nombre)
        {
            Categorias? tmp = catgories.FirstOrDefault(x => x.CategoriaId == cagoira_id);

            if (tmp != null)
            {
                return new BaseResponse(false, (int)HttpStatusCode.Conflict, "Categoria ya existe");
            }
            else
            {
                Categorias newCategoria = new Categorias(cagoira_id, nombre);
                catgories.Add(newCategoria);

                return new DataResponse<Categorias>(true, (int)HttpStatusCode.Created, "Categoria creada", data: newCategoria);
            }
        }
    }
}
