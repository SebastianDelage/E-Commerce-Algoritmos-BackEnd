namespace E_commerce.Repository.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaOrden {  get; set; }
        public int Estado {  get; set; }
        public decimal Total {  get; set; }
    }
}
