using System.Runtime.CompilerServices;

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
        //por quie este no tiene que ser static?
        public string CreateCategoria()
        {
            return string.Format($"INSERT INTO categorias (nombre) VALUES ('{Nombre}')");
        }

        public string UpdateCategoriaById(int id,string nombre)
        {
            return string.Format($"UPDATE categorias SET nombre = '{nombre}' WHERE categoria_id = {id}");
        }

    }
}
