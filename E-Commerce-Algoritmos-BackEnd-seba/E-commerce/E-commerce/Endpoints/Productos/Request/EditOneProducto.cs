using E_commerce.Responses;
using E_commerce.Repository.Models;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Endpoints.Productos.Request
{

    public class EditOneProducto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int CategoriaID { get; set; }
        public int MarcaId { get; set; }
        public int GeneroId { get; set; }
        public string ImagenUrl { get; set; }
    }
}