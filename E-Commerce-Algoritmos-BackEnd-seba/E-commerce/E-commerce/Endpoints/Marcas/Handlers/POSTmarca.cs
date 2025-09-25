using E_commerce.Repository.Models;
using E_commerce.Responses;
using System.Net;

namespace E_commerce.Endpoints.Marcas.Handlers
{
    public class POSTmarca
    {
        public static BaseResponse CrateMarca(List<Marca> marcas, int id_marca, string nombre)
        {
            Marca? tmp = marcas.FirstOrDefault(x => x.MarcaId == id_marca);
            if (tmp != null)
            {
                return new BaseResponse(false, (int)HttpStatusCode.Conflict, "Marca ya existe");
            }
            else
            {
                Marca newMarca = new Marca(id_marca, nombre);
                marcas.Add(newMarca);
                return new DataResponse<Marca>(true, (int)HttpStatusCode.Created, "Marca creada", data: newMarca);
            }
        }
    }
}
