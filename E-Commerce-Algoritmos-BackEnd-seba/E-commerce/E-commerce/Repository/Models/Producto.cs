using System.Runtime.CompilerServices;

namespace E_commerce.Repository.Models
{
    public class Producto
    {
        public int producto_id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int CategoriaID { get; set; }
        public int MarcaId { get; set; }
        public int GeneroId { get; set; }
        public string ImagenUrl { get; set; }

        public Producto(int producto_id,string name,string descripcion,float precio,int categoria_id,int marca_id,int genero_id,string imagenURL) {
            this.Nombre = name;
            this.Precio = precio;
            this.Descripcion = descripcion;
            this.CategoriaID = categoria_id;
            this.MarcaId = marca_id;
            this.GeneroId = genero_id;
            this.ImagenUrl = imagenURL;
            this.producto_id = producto_id;
        }

        public Producto()
        {

        }
    }
}
