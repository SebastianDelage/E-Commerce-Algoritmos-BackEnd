namespace E_commerce.Endpoints.Usuarios.Handlers
{
    public static class UsuariosQuery
    {
        public const string GetAll = "SELECT * FROM usuarios;";
        public const string GetById = @"SELECT usuario_id AS UsuarioId, nombre AS Nombre, email AS Email, contraseña, direccion AS Direccion, telefono AS Telefono 
                                    FROM usuarios WHERE usuario_id = ?;";
        public const string DeleteById = "DELETE FROM usuarios WHERE usuario_id = ?;";
        public const string UpdateUsuario = @"UPDATE usuarios SET nombre = ?, email = ?, contraseña = ?, direccion = ?, telefono = ?; 
                                    WHERE usuario_id = ?;";
        public const string CreateUsuario = @"INSERT INTO usuarios (nombre,email,contraseña,direccion,telefono ) VALUES (?, ?, ?, ?,?);";
        public const string GetUsuarioPerfilByEmail = @"
                                SELECT 
                                    u.usuario_id AS usuario_id,
                                    u.perfil_id AS perfil_id,
                                    u.nombre AS nombre,
                                    u.email AS email,
                                    u.contraseña,
                                    u.direccion AS direccion,
                                    u.telefono AS telefono,
                                    p.nombre AS perfilNombre
                                FROM usuarios u
                                INNER JOIN perfil p ON u.perfil_id = p.perfil_id
                                WHERE u.email = ?;";

    }
}
