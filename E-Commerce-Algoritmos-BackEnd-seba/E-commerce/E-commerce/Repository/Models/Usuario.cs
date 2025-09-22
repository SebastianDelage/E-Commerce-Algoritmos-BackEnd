    namespace E_commerce.Repository.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Direccion {  get; set; }
        public string Telefono { get; set; }

        public Usuario() { }

        public Usuario(int usuarioId, string nombre, string email, string contraseña, string direccion, string telefono)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Email = email;
            Contraseña = contraseña;
            Direccion = direccion;
            Telefono = telefono;
        }

        public static string GetAllUsuarios()
        {
            return string.Format("SELECT * FROM usuarios");
        }

        public static string GetUsuarioById(int id)
        {
            return string.Format($"SELECT * FROM usuarios where usuario_id ={id}");
        }
    }
}
