namespace E_commerce.Endpoints.Usuarios.Handlers
{
    public static class UsuariosQuery
    {
        public const string GetAll = "SELECT * FROM usuarios;";
        public const string GetById = @"SELECT usuario_id AS UsuarioId, nombre AS Nombre, email AS Email, contraseña AS Password, direccion AS Direccion, telefono AS Telefono 
                                    FROM usuarios WHERE usuario_id = ?;";
        public const string DeleteById = "DELETE FROM usuarios WHERE usuario_id = ?;";
        public const string UpdateUsuario = @"UPDATE usuarios SET nombre = ?, email = ?, contraseña = ?, direccion = ?, telefono = ?; 
                                    WHERE usuario_id = ?;";
        public const string CreateUsuario = @"INSERT INTO usuarios (nombre,email,contraseña,direccion,telefono ) VALUES (?, ?, ?, ?,?);";
    }
}
