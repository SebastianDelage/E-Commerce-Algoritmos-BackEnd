namespace E_commerce.Repository.Models
{
    public class DetalleOrdenes
    {
        public int detalleOrden_id { get; set; }
        public int OrdenId { get; set; }
        public int StockId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public DetalleOrdenes() { }

        public DetalleOrdenes(int detalleOrdenId, int ordenId, int stockId, int cantidad, decimal precioUnitario)
        {
            detalleOrden_id = detalleOrdenId;
            OrdenId = ordenId;
            StockId = stockId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }


    }
}
