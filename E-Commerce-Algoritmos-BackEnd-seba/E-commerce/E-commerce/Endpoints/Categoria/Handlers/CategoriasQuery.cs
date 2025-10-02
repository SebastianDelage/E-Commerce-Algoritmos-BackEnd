using E_commerce.Repository.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerce.Endpoints.Categoria.Handlers
{
    public static class CategoriasQuery
    {

        public const string GetAllCategorias = "SELECT * FROM categorias;";

        public static string GetCategoriaById(int id)
        {
            return string.Format(" SELECT * FROM categorias WHERE categoria_id = {0};", id);
        }

        public const string DeleteCategoriaById = "DELETE FROM categorias where categoria_id = ?;";

        public const string UpdateCategoria = "UPDATE categorias SET nombre = ? WHERE categoria_id = ?;";

        public const string CreateCategoria = "INSERT INTO categorias (nombre) VALUES (?);";



    }
}
