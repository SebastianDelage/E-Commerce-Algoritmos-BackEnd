namespace E_commerce.Endpoints.Talles.Handlers
{
    public static class TallesQuery
    {
        public const string GetAll = "SELECT * FROM talles;";
        public const string GetById = "SELECT talle_id AS TalleId, nombre AS Nombre FROM talles WHERE talle_id = ?;";
        public const string DeleteById = "DELETE FROM talles WHERE talle_id = ?;";
        public const string UpdateTalle = "UPDATE talles SET nombre = ? WHERE talle_id = ?;";
        public const string CreateTalle = "INSERT INTO talles (nombre) VALUES (?);";
    }
}
