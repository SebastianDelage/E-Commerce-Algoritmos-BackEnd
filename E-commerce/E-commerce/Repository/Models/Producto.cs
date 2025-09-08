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
}
