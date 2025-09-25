namespace E_commerce.Repository.Models
{
    public class DetalleOrdenes
    {
        public int DetalleOrdenId { get; set; }
        public int OrdenId { get; set; }
        public int StockId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public DetalleOrdenes() { }

        public DetalleOrdenes(int detalleOrdenId, int ordenId, int stockId, int cantidad, decimal precioUnitario)
        {
            DetalleOrdenId = detalleOrdenId;
            OrdenId = ordenId;
            StockId = stockId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        public static string GetAllDetalleOrden()
        {
            return string.Format("SELECT * FROM detalle_orden");
        }

        public static string GetDetalleOrdenById(int id)
        {
            return string.Format($"SELECT * FROM detalle_orden where detalle_orden_id ={id}");
        }

        public static string CreateDetalleOrden(int ordenId, int stockId, int cantidad, decimal precioUnitario)
        {
            return string.Format($"INSERT INTO detalle_orden (orden_id, stock_id, cantidad, precio_unitario) VALUES ({ordenId}, {stockId}, {cantidad}, {precioUnitario})");
        }

        public static string UpdateDetalleOrden(int id, int ordenId, int stockId, int cantidad, decimal precioUnitario)
        {
            return string.Format($"UPDATE detalle_orden SET orden_id = {ordenId}, stock_id = {stockId}, cantidad = {cantidad}, precio_unitario = {precioUnitario} WHERE detalle_orden_id = {id}");
        }
    }
}
