namespace E_commerce.Repository.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre {  get; set; }
    

        public Marca() { }

        public Marca(int marcaId, string nombre)
        {
            MarcaId = marcaId;
            Nombre = nombre;
        }
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
