namespace E_commerce.Endpoints.Productos.Handlers
{
    public static class ProductoQuery
    {
        public const string GetAll = "SELECT * FROM productos;";
        public const string GetById = @"SELECT producto_id AS ProductoId, nombre AS Nombre, descripcion AS Descripcion, precio AS Precio, stock AS Stock, marca_id AS MarcaId, categoria_id AS CategoriaId 
                                    FROM productos WHERE producto_id = ?;";
        public const string DeleteById = "DELETE FROM productos WHERE producto_id = ?;";
        public const string UpdateProducto = @"UPDATE productos SET nombre = ?, descripcion = ?, precio = ?, stock = ?, marca_id = ?, categoria_id = ? 
                                    WHERE producto_id = ?;";
        public const string CreateProducto = @"INSERT INTO productos (nombre, descripcion, precio, stock, marca_id, categoria_id) VALUES (?, ?, ?, ?, ?, ?);";
    }
}
