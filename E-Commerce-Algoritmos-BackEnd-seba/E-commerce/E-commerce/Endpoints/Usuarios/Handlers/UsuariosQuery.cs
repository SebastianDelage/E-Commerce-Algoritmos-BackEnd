namespace E_commerce.Endpoints.Usuarios.Handlers
{
    public static class UsuariosQuery
    {
        public const string GetAll = "SELECT * FROM usuarios;";
        public const string GetById = @"
                                        SELECT u.usuario_id AS UsuarioId,
                                               u.nombre AS Nombre,
                                               u.email AS Email,
                                               u.contraseña AS Password,
                                               u.direccion AS Direccion,
                                               u.telefono AS Telefono,
                                               p.nombre AS PerfilNombre
                                        FROM usuarios u
                                        INNER JOIN perfil p ON u.perfil_id = p.perfil_id
                                        WHERE u.usuario_id = ?;";
        public const string DeleteById = "DELETE FROM usuarios WHERE usuario_id = ?;";
        public const string UpdateUsuario = @"UPDATE usuarios SET nombre = ?, email = ?, contraseña = ?, direccion = ?, telefono = ?; 
                                    WHERE usuario_id = ?;";
        public const string CreateUsuario = @"
                                            INSERT INTO usuarios (nombre, email, contraseña, direccion, telefono, perfil_id)
                                            VALUES (?, ?, ?, ?, ?, ?);";
        public const string GetUsuarioPerfilByEmail = @"
                                                        SELECT u.usuario_id AS UsuarioId,
                                                               u.nombre AS Nombre,
                                                               u.email AS Email,
                                                               u.contraseña AS Password,
                                                               u.direccion AS Direccion,
                                                               u.telefono AS Telefono,
                                                               p.nombre AS PerfilNombre
                                                        FROM usuarios u
                                                        INNER JOIN perfil p ON u.perfil_id = p.perfil_id
                                                        WHERE u.email = ?;";

    }
}
