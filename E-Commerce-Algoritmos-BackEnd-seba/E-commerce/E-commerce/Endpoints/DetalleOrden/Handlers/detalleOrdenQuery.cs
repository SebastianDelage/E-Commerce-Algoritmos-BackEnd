namespace E_commerce.Endpoints.DetalleOrden.Handlers
{
    public static class detalleOrdenQuery
    {
        public const string GetAllDetalleOrden = @"SELECT detalleOrden_id AS DetalleOrdenId, orden_id AS OrdenId, stock_id AS StockId, cantidad AS Cantidad, precioUnitario AS Precio 
                                    FROM detalleOrden;";
        public const string GetDetalleOrdenById = @"SELECT detalleOrden_id AS DetalleOrdenId, orden_id AS OrdenId, stock_id AS StockId, cantidad AS Cantidad, precioUnitario AS Precio
                                    FROM detalleOrden WHERE detalleOrden_id = ?;";
        public const string DeleteDetalleOrdenById = "DELETE FROM detalleOrden WHERE detalleOrden_id = ?;";
        public const string UpdateDetalleOrden = @"UPDATE detalleOrden SET orden_id = ?, stock_id = ?, cantidad = ?, precioUnitario = ? 
                                    WHERE detalleOrden_id = ?;";
        public const string CreateDetalleOrden = @"INSERT INTO detalleOrden (orden_id, stock_id, cantidad, precioUnitario)
                                    VALUES (?, ?, ?, ?);";

    }
}
