namespace E_commerce.Repository.Models
{
    public class Talle
    {
        public int TalleId { get; set; }
        public string Nombre { get; set; }


        public Talle() { }

        public Talle(int talleId, string nombre)
        {
            TalleId = talleId;
            Nombre = nombre;
        }
        public static string GetAllTalles()
        {
            return string.Format("SELECT * FROM talles");
        }

        public static string GetTalleById(int id)
        {
            return string.Format($"SELECT * FROM talles where talle_id ={id}");
        }
    }
}
