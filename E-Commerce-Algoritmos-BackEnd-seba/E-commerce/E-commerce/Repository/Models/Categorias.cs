namespace E_commerce.Repository.Models
{
    public class Categorias
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }


        public Categorias() { }

        public Categorias(int categoriaId, string nombre)
        {
            CategoriaId = categoriaId;
            Nombre = nombre;
        }

        public static string GetAllCategorias()
        {
            return string.Format("SELECT * FROM categorias");
        }

        public static string GetCategoriaById(int id)
        {
            return string.Format($"SELECT * FROM categorias where categoria_id ={id}");
        }

        public static string CreateCategoria(string nombre)
        {
            return string.Format($"INSERT INTO categorias (nombre) VALUES ('{nombre}')");
        }

    }
}
