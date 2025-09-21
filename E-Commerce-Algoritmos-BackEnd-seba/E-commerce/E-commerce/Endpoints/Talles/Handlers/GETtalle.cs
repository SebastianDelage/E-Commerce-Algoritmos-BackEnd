using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;


namespace E_commerce.Endpoints.Talles.Handlers
{
    public class GETtalle
    {
        static public BaseResponse GetAllTalles(List<Talle> talles)
        {
            return new DataResponse<List<Talle>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: talles);
        }

        static public BaseResponse GetTalleById(List<Talle> talles, int id_talle)
        {
            Talle? tmp = talles.FirstOrDefault(x => x.TalleId == id_talle);
            if (tmp != null)
            {
                return new DataResponse<Talle>(true, (int)HttpStatusCode.OK, "Talle encontrado", data: tmp);
            }
            else
            {
                return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Talle no encontrado");
            }
        }
    }
}


