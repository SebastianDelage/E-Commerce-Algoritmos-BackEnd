namespace E_commerce.Repository.Models
{
    public class Genero
    {
        public int genero_id { get; set; }
        public string Nombre { get; set; }

        public Genero() { }

        public Genero(int generoId, string nombre)
        {
            genero_id = generoId;
            Nombre = nombre;
        }

    }
}
