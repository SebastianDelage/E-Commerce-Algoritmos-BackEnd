namespace E_commerce.Repository.Models
{
    public class Marcas
    {
        public int MarcaId { get; set; }
        public string Nombre {  get; set; }
    
        public static string GetAllMarcas()
        {
            return string.Format("SELECT * FROM marcas");
        }

        public static string GetMarcaById(int id)
        {
            return string.Format($"SELECT * FROM marcas where marca_id ={id}");
        }

    }
}
