namespace E_commerce.Endpoints.Colores.Handlers
{
    public static class ColoresQuery
    {
        public const string GetAllColores = "SELECT * FROM colores;";
        public static string GetColorById(int id)
        {
            return string.Format("SELECT * FROM colores WHERE color_id = {0}", id);
        }
        public const string DeleteColorById = "DELETE FROM colores where color_id = ?;";
        public const string UpdateColor = "UPDATE colores SET nombre = ?, codigo = ? WHERE color_id = ?;";
        public const string CreateColor = "INSERT INTO colores (nombre, codigo) VALUES (?, ?);";
    }
}
