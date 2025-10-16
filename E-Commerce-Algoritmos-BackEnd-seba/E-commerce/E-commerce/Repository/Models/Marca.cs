namespace E_commerce.Repository.Models
{
    public class Marca
    {
        public int marca_id { get; set; }
        public string Nombre {  get; set; }
    
        
        public Marca() { }

        public Marca(int marcaId, string nombre)
        {
            marca_id = marcaId;
            Nombre = nombre;
        }


    }
}
