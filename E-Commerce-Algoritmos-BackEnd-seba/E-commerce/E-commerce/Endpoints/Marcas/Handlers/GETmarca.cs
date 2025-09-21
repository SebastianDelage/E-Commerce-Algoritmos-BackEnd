using E_commerce.E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
using E_commerce.Responses;

using namespace E_commerce.Endpoints.Marcas.Handlers
{
	public class GETmarca
{
	public static BaseResponse GetAllMarcas(List<Marcas> marcas)
	{
	   return new DataResponse<Marcas>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: marcas
	}
	public static BaseResponse GetMarcaById(List<Marcas> marcas, int id_marca)
	{
		Marcas? tmp = marcas.FirstOrDefault(x => x.MarcaId == id_marca);
		if (tmp != null)
		{
			return new DataResponse<List<Marcas>>(true, (int)HttpStatusCode.OK, "Lista encontrada", data: marcas);
		}
		else
		{
			return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Marca no encontrada");
		}
	}
}
}