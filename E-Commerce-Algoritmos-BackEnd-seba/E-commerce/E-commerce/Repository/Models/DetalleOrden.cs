namespace E_commerce.Repository.Models
{
    public class DetalleOrden
    {
        public int DetalleOrdenId { get; set; }
        public int OrdenId { get; set; }
        public int StockId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    
        public static string GetAllDetalleOrden()
        {
            return string.Format("SELECT * FROM detalle_orden");
        }

        public static string GetDetalleOrdenById(int id)
        {
            return string.Format($"SELECT * FROM detalle_orden where detalle_orden_id ={id}");
        }
    }
}
