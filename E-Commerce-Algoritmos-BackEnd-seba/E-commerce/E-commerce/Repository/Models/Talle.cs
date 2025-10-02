namespace E_commerce.Repository.Models
{
    public class Talle
    {
        public int TalleId { get; set; }
        public string Nombre { get; set; }


        public Talle() { }

        public Talle(int talleId, string nombre)
        {
            TalleId = talleId;
            Nombre = nombre;
        }

    }
}
