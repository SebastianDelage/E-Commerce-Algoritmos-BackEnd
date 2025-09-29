using System.Runtime.CompilerServices;

namespace E_commerce.Repository.Models
{
    public class Categorias
    {

        //las propiedades deben tener el mismo nombre que las columnas de la base de datos
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

        public string CreateCategoria()
        {
            return string.Format($"INSERT INTO categorias (nombre) VALUES ('{Nombre}')");
        }

        public string UpdateCategoriaById()
        {
            return string.Format($"UPDATE categorias SET nombre = '{Nombre}' WHERE categoria_id = {CategoriaId}");
        }

    }
}
