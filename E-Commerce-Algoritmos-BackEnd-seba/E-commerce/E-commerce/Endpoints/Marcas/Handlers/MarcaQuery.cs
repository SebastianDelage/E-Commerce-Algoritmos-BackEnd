namespace E_commerce.Endpoints.Marcas.Handlers
{
    public static class MarcaQuery
    {
        public const string GetAll = "SELECT * FROM marcas;";
        public static string GetMarcaById(int id)
        {
            return string.Format("SELECT * FROM marcas WHERE marca_id = {0}", id);
        }
        public const string DeleteById = "DELETE FROM marcas WHERE marca_id = ?;";
        public const string UpdateMarca = "UPDATE marcas SET nombre = ? WHERE marca_id = ?;";
        public const string CreateMarca = "INSERT INTO marcas (nombre) VALUES (?);";

    }
}
