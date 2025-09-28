namespace E_commerce.Repository.Models
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaOrden {  get; set; }
        public int Estado {  get; set; }
        public decimal Total {  get; set; }

        public Orden() { }

        public Orden(int ordenId, int usuarioId, DateTime fechaOrden, int estado, decimal total)
        {
            OrdenId = ordenId;
            UsuarioId = usuarioId;
            FechaOrden = fechaOrden;
            Estado = estado;
            Total = total;
        }

        public static string GetAllOrdenes()
        {
            return string.Format("SELECT * FROM ordenes");
        }

        public static string GetOrdenById(int id)
        {
            return string.Format($"SELECT * FROM ordenes where orden_id ={id}");
        }

        public string InsertOrden()
        {
            return string.Format($"INSERT INTO ordenes (usuario_id, fecha_orden, estado, total) VALUES ({UsuarioId}, '{FechaOrden.ToString("yyyy-MM-dd HH:mm:ss")}', {Estado}, {Total})");
        }

        public string UpdateOrden(int id)
        {
            return string.Format($"UPDATE ordenes SET usuario_id = {UsuarioId}, fecha_orden = '{FechaOrden.ToString("yyyy-MM-dd HH:mm:ss")}', estado = {Estado}, total = {Total} WHERE orden_id = {OrdenId}");
        }
    }
}
