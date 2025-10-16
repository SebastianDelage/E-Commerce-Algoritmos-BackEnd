namespace E_commerce.Repository.Models
{
    public class Orden
    {
        public int orden_id { get; set; }
        public int usuario_id { get; set; }
        public DateTime FechaOrden {  get; set; }
        public int Estado {  get; set; }
        public decimal Total {  get; set; }

        public Orden() { }

        public Orden(int ordenId, int usuarioId, DateTime fechaOrden, int estado, decimal total)
        {
            orden_id = ordenId;
            usuario_id = usuarioId;
            FechaOrden = fechaOrden;
            Estado = estado;
            Total = total;
        }
    }
}
