using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.Genero.Handlers
{
    public class GETgenero
    {
        public static BaseResponse GetAllGeneros(List<Genero> generos)
        {
            return new DataResponse<List<Genero>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: generos);
        }

        public static BaseResponse GetGeneroById(List<Genero generos), int id_genero)
        {
            Genero? tmp = generos.FirstOrDefault(x => x.GeneroId == id_genero);
            if (tmp != null)
            {
                return new DataResponse<Genero>(true, (int)HttpStatusCode.OK, "Genero encontrado", data: tmp);
            }
            else
            {
                return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Genero no encontrado");
}
        }
    }
}


