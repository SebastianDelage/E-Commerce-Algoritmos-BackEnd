namespace E_commerce.Endpoints.StockProductos.Handlers
{
    public static class StockProductoQuery
    {
        public const string GetAll = "SELECT * FROM stockProducto;";
        public const string GetById = @"SELECT stock_id AS StockId, producto_id AS ProductoId, cantidad AS Cantidad, fecha_entrada AS FechaEntrada, fecha_salida AS FechaSalida 
                                    FROM stockProducto WHERE stock_id = ?;";
        public const string DeleteById = "DELETE FROM stockProducto WHERE stock_id = ?;";
        public const string UpdateStockProducto = @"UPDATE stockProducto SET producto_id = ?, cantidad = ?, fecha_entrada = ?, fecha_salida = ? 
                                    WHERE stock_id = ?;";
        public const string CreateStockProducto = @"INSERT INTO stockProducto (producto_id, cantidad, fecha_entrada, fecha_salida) VALUES (?, ?, ?, ?);";
    }
}
