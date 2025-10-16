namespace E_commerce.Repository.Models
{
    public class StockProducto
    {
        public int stock_id { get; set; }
        public int producto_id { get; set; }
        public int talles_id { get; set; }
        public int color_id { get; set; }
        public int Cantidad {  get; set; }

        public StockProducto() { }

        public StockProducto(int stockId, int productoId, int talleId, int colorId, int cantidad)
        {
            stock_id = stockId;
            producto_id = productoId;
            talles_id = talleId;
            color_id = colorId;
            Cantidad = cantidad;
        }
    }
}
