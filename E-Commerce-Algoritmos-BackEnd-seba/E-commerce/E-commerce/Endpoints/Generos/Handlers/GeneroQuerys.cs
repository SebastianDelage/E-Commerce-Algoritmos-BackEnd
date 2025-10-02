namespace E_commerce.Endpoints.Generos.Handlers
{
    public static class GeneroQuerys
    {
        public const string GetAll = "SELECT * FROM generos";

        public const string GetById = "SELECT genero_id AS GeneroId, nombre AS Nombre FROM generos WHERE genero_id = ?";
    }
}
