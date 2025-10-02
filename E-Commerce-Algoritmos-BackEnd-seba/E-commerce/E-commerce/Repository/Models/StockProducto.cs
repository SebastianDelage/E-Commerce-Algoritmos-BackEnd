namespace E_commerce.Repository.Models
{
    public class StockProducto
    {
        public int stock_id { get; set; }
        public int ProductoId { get; set; }
        public int TallesId { get; set; }
        public int ColorId { get; set; }
        public int Cantidad {  get; set; }

        public StockProducto() { }

        public StockProducto(int stockId, int productoId, int talleId, int colorId, int cantidad)
        {
            stock_id = stockId;
            ProductoId = productoId;
            TallesId = talleId;
            ColorId = colorId;
            Cantidad = cantidad;
        }
    }
}
