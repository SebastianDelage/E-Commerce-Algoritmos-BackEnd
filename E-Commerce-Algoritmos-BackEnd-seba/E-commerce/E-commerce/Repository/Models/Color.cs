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
        public static string GetAllColores()
        {
            return string.Format("SELECT * FROM colores");
        }

        public static string GetColorById(int id)
        {
            return string.Format($"SELECT * FROM colores where color_id ={id}");
        }

        public string CreateColor(string nombre, string codigo)
        {
            return string.Format($"INSERT INTO colores (nombre, codigo) VALUES ('{nombre}', '{codigo}')");
        }
    }
}
