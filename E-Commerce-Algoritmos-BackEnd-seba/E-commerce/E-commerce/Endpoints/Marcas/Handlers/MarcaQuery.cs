namespace E_commerce.Endpoints.Marcas.Handlers
{
    public static class MarcaQuery
    {
        public const string GetAll = "SELECT * FROM marcas;";
        public const string GetById = "SELECT marca_id AS MarcaId, nombre AS Nombre FROM marcas WHERE marca_id = ?;";
        public const string DeleteById = "DELETE FROM marcas WHERE marca_id = ?;";
        public const string UpdateMarca = "UPDATE marcas SET nombre = ? WHERE marca_id = ?;";
        public const string CreateMarca = "INSERT INTO marcas (nombre) VALUES (?);";
    }
}
