namespace E_commerce.Repository.Models
{
    public class StockProducto
    {
        public int StockId { get; set; }
        public int ProductoId { get; set; }
        public int TallesId { get; set; }
        public int ColorId { get; set; }
        public int Stock {  get; set; }

        public StockProducto() { }

        public StockProducto(int stockId, int productoId, int talleId, int colorId, int stock)
        {
            StockId = stockId;
            ProductoId = productoId;
            TallesId = talleId;
            ColorId = colorId;
            Stock = stock;
        }
        public static string GetAllStockProductos()
        {
            return string.Format("SELECT * FROM stock_productos");
        }

        public static string GetStockProductoById(int id)
        {
            return string.Format($"SELECT * FROM stock_productos where stock_id ={id}");
        }

        public string CreateStockProducto()
        {
            return string.Format($"INSERT INTO stock_productos (producto_id, talle_id, color_id, stock) VALUE ( {ProductoId}, {TallesId}, {ColorId}, {Stock})");
        }

        public string UpdateStockProducto(int id)
        {
            return string.Format($"UPDATE stock_productos SET producto_id = {ProductoId}, talle_id = {TallesId}, color_id = {ColorId}, stock = {Stock} WHERE stock_id = {id}");
        }
    }
}
