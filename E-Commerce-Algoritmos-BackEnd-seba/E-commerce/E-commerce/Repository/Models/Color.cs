namespace E_commerce.Repository.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public Color() { }

        public Color(int colorId, string nombre, string codigo)
        {
            ColorId = colorId;
            Nombre = nombre;
            Codigo = codigo;
        }
    }
}
