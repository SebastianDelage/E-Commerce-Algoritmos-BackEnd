namespace E_commerce.Repository.Models
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set; }

        public Genero() { }

        public Genero(int generoId, string nombre)
        {
            GeneroId = generoId;
            Nombre = nombre;
        }

    }
}
