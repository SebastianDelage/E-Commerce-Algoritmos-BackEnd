using System.Runtime.CompilerServices;

namespace E_commerce.Repository.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
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
            this.ProductoId = producto_id;
        }

        public Producto()
        {

        }


        public static string GetAllProductos()
        {
            return string.Format("SELECT * FROM productos");
        }

        public static string GetProductoById(int id)
        {
            return string.Format($"SELECT * FROM producto where producto_id ={id}");

        }

        public static string CreateOneProducto()
        {
            return string.Format("INSERT INTO producto ({0},{1},{2},{3},{4},{5},{6})");
        }
    }
}
