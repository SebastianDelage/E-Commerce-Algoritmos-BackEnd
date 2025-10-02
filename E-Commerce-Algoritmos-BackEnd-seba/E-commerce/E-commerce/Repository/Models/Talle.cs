namespace E_commerce.Repository.Models
{
    public class Talle
    {
        public int talle_id { get; set; }
        public string Nombre { get; set; }


        public Talle() { }

        public Talle(int talleId, string nombre)
        {
            talle_id = talleId;
            Nombre = nombre;
        }

    }
}
