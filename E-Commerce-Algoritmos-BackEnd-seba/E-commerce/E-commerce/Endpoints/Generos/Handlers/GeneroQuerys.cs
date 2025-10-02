namespace E_commerce.Endpoints.Generos.Handlers
{
    public static class GeneroQuerys
    {
        public const string GetAll = "SELECT * FROM generos";

       public static string GetById(int id)
        {
            return string.Format("SELECT * FROM generos WHERE genero_id = {id}", id);
        }
    }
}
