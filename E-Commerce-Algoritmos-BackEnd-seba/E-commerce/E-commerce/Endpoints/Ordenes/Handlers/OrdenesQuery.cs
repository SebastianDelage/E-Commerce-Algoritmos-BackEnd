namespace E_commerce.Endpoints.Ordenes.Handlers
{
    public static class OrdenesQuery
    {
        public const string GetAllOrdenes = "SELECT * FROM ordenes;";
        public const string GetOrdenById = @"SELECT orden_id AS OrdenId, usuario_id AS UsuarioId, fecha AS Fecha, total AS Total 
                                    FROM ordenes WHERE orden_id = ?;";
        public const string DeleteOrdenById = "DELETE FROM ordenes WHERE orden_id = ?;";
        public const string UpdateOrden = @"UPDATE ordenes SET usuario_id = ?, fecha = ?, total = ? 
                                    WHERE orden_id = ?;";
        public const string CreateOrden = @"INSERT INTO ordenes (usuario_id, fecha, total) VALUES (?, ?, ?);";
    }
}
