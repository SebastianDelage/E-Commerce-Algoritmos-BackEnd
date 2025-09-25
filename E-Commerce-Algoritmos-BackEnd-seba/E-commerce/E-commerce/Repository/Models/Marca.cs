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

        public static string CreateMarca(int marcaId, string nombre)
        {
            return string.Format($"INSERT INTO marcas (marca_id, nombre) VALUES ({marcaId}, '{nombre}')");
        }
        public static string UpdateMarca(int id, string nombre)
        {
            return string.Format($"UPDATE marcas SET nombre = '{nombre}' WHERE marca_id = {id}");
        }

    }
}
