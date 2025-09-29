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

        public string CreateProducto()
        {
            return string.Format($"INSERT INTO productos (nombre, descripcion, precio, categoria_id, marca_id, genero_id, imagen_url) VALUES ('{Nombre}', '{Descripcion}', {Precio}, {CategoriaID}, {MarcaId}, {GeneroId}, '{ImagenUrl}')");
        }

        public string UpdateProducto(int id)
        {
            return string.Format($"UPDATE productos SET nombre = '{Nombre}', descripcion = '{Descripcion}', precio = {Precio}, categoria_id = {CategoriaID}, marca_id = {MarcaId}, genero_id = {GeneroId}, imagen_url = '{ImagenUrl}' WHERE producto_id = {id}");
        }
    }
}
