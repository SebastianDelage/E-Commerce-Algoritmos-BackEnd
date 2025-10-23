namespace E_commerce.Endpoints.Promocio.Handlers
{
    public class PromocionesQuery
    {
        public const string GetAllPromociones = "SELECT * FROM promociones";
        public string GetPromocionesById(int id)
        {
            return string.Format($"SELECT * FROM promociones WHERE promociones_id = {id}");
        }

        public const string CreatePromocion = @"INSERT INTO promociones (nombre, tipo, valor, estado) VALUES (?,?,?,?);";
        public const string UpdatePromocion = @"UPDATE promociones SET nombre = ?, tipo = ?, valor = ?,estado = ? ;";

    }
}
