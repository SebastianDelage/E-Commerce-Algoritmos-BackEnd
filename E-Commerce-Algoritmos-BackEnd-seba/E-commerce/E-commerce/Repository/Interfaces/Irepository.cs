namespace E_commerce.Repository.Interfaces
{
    public interface IRepository <T>  where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string query);//para tarer mas de un resultado
        Task<T?> GetByIdAsync(string query);//traer de a un solo resultado
        Task<int> ExecuteAsync(string query);//ejecuta cualquier query
        Task<int> AddAsync(string query);//agregar un nuevo registro
        Task<int> UpdateAsync(string query);//actualizar un registro
    }
}
