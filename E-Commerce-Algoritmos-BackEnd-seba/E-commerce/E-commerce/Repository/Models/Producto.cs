using System.Runtime.CompilerServices;

namespace E_commerce.Repository.Models
{
    public class Producto
    {
        public int producto_id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int categoria_id { get; set; }
        public int marca_id { get; set; }
        public int genero_id { get; set; }
        public string ImagenUrl { get; set; }
        public int promocion_id { get; set; }
        public string nombrePromo { get; set; }


        public Producto(int producto_id,string name,string descripcion,float precio,int categoria_id,int marca_id,int genero_id,string imagenURL,int promocion_id,string nombrePromo) {
            this.Nombre = name;
            this.Precio = precio;
            this.Descripcion = descripcion;
            this.categoria_id = categoria_id;
            this.marca_id = marca_id;
            this.genero_id = genero_id;
            this.ImagenUrl = imagenURL;
            this.producto_id = producto_id;
            this.promocion_id = promocion_id;
            this.nombrePromo = nombrePromo;

        }

        public Producto()
        {

        }
    }
}
