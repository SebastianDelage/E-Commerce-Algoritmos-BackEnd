using E_commerce.Repository.Models;
using E_commerce.Responses;

namespace E_commerce.Endpoints.Colores.Handlers
{
    public class PATCHcolores
    {
        public static BaseResponse UpdateColores(int id_color)
        {
           
                return new DataResponse<Color>(true, (int)System.Net.HttpStatusCode.OK, "color creado");
        
        }
    }
}
 