namespace E_commerce.Endpoints.Colores.Handlers
{
    public static class ColoresQuery
    {
        public const string GetAllColores = "SELECT * FROM colores;";
        public const string GetColorById = " SELECT color_id AS ColorId, nombre AS Nombre, codigo AS Codigo FROM colores WHERE color_id = ?;";
        public const string DeleteColorById = "DELETE FROM colores where color_id = ?;";
        public const string UpdateColor = "UPDATE colores SET nombre = ?, codigo = ? WHERE color_id = ?;";
        public const string CreateColor = "INSERT INTO colores (nombre, codigo) VALUES (?, ?);";
    }
}
