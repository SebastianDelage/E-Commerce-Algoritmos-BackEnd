using System.Runtime.CompilerServices;

namespace E_commerce.Repository.Models
{
    public class Categorias
    {

        //las propiedades deben tener el mismo nombre que las columnas de la base de datos
        public int categoria_id{ get; set; }
        public string Nombre { get; set; }


        public Categorias() { }

        public Categorias(int categoriaId, string nombre)
        {
            categoria_id = categoriaId;
            Nombre = nombre;
        }
    }
}
