
using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;
namespace E_commerce.Endpoints.DetalleOrden.Handlers
{

    public class GETdetalleOrden
    {      
        public static BaseResponse GetAllDetalleOrden()
        {
            return new DataResponse<List<DetalleOrdenes>>(true, (int)HttpStatusCode.OK, "Lista encontrada");
        }

        public static BaseResponse GetDetalleOrdenById(int id_detalleOrden)
        {

                return new DataResponse<DetalleOrdenes>(true, (int)HttpStatusCode.OK, "Detalle de Orden encontrado");

        }
    }
}
