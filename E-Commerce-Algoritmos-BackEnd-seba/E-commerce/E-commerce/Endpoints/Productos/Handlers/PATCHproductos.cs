using System;

using namespace E_commerce.Endpoints.Productos.Handlers;

using E_commerce.Repository.Interfaces;
using E_commerce.Responses;
using E_commerce.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using E_commerce.Endpoints.Productos.Request;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using System.Net;

public class  PATCHproductos
{
    public static BaseResponse EditOnePersona (List<EditOneProducto>product, int id_producto,string descripcion)
    {
        Producto? tmp = product.FirstOrDefault(x => x.ProductoId == id_producto);

        if (tmp == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "Producto no eecontrado");
        }
        else
        {
            product.Remove(tmp);
            tmp.Descripcion = descripcion;
            product.Add(tmp);

            return new DataResponse<Producto>(true, (int)HttpStatusCode.OK, "Producto modificado", data:tmp);
        }
    }
}