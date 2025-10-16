namespace E_commerce.Repository.Models
{
    public class Talle
    {
        public int talles_id { get; set; }
        public string Nombre { get; set; }


        public Talle() { }

        public Talle(int talleId, string nombre)
        {
            talles_id = talleId;
            Nombre = nombre;
        }

    }
}
