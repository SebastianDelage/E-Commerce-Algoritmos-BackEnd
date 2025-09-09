namespace E_commerce.Repository.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion {  get; set; }
        public float precio { get; set; }
        public int CategoriaID {  get; set; }
        public int MarcaId { get; set; }
        public int GeneroId {  get; set; }
        public string ImagenUrl { get; set; }

        public Producto() { }
    }

    public static string GetAllProductos()
    {
        return string.Format("SELECT * FROM productos");
    }

    public static string GetProductoById(int id)
    {
        return string.Format("SELECT * FROM producto where producto_id ="id);
    }
}
