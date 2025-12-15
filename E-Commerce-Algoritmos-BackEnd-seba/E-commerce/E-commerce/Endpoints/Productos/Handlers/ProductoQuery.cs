using System.Globalization;

namespace E_commerce.Endpoints.Productos.Handlers
{
    public static class ProductoQuery
    {
        public const string GetAll = "SELECT * FROM productos;";
        public static string GetAllById(int id)
        {
            return string.Format($"SELECT * FROM productos WHERE producto_id = {id}");
        }
        public static string GetProductoByGenero(int id)
        {
            return string.Format($"SELECT * FROM productos WHERE genero_id  = {id};");
        }
        public static string GetProductoById(int id)
        {
            return string.Format($"SELECT * FROM productos as p WHERE p.categoria_id = {id}");
        }
        public const string DeleteById = "DELETE FROM productos WHERE producto_id = ?;";
        public const string UpdateProducto = @"
                    UPDATE productos
                        SET
                          nombre = ?,
                          descripcion = ?,
                          precio = ?,
                          marca_id = ?,
                          genero_id = ?,
                          categoria_id = ?
                        WHERE producto_id = ?;";
        public const string CreateProducto = @"INSERT INTO productos (nombre, descripcion, precio, marca_id, categoria_id,genero_id) VALUES (?, ?, ?, ?, ?,?);";

        public static string GetProductoPromocion(int estado)
        {
            return $@"
        SELECT p.*
        FROM productos p
        INNER JOIN promociones p2 ON p.promocion_id = p2.promocion_id
        WHERE p2.estado = {estado};
    ";
        }



    }
}
