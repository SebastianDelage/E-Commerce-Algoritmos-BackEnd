namespace E_commerce.Repository.Models
{
    public class Generos
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set; }

        public static string GetAllGeneros()
        {
            return string.Format("SELECT * FROM generos");
        }

        public static string GetGeneroById(int id)
        {
            return string.Format($"SELECT * FROM generos where genero_id ={id}");
        }

    }
}
