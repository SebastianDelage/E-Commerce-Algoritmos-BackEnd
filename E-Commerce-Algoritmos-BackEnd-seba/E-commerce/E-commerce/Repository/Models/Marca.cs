namespace E_commerce.Repository.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nombre {  get; set; }
    
        
        public Marca() { }

        public Marca(int marcaId, string nombre)
        {
            MarcaId = marcaId;
            Nombre = nombre;
        }


    }
}
