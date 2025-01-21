namespace ElasticsearchExample.ElasticsearchService.Services
{
    public interface IElasticsearchService
    {
        Task CreateIndexIfNotExistsAsync(string indexName);
        Task InsertAsync<T>(string indexName, T document) where T : class;
        Task<T> GetByIdAsync<T>(string indexName, string id) where T : class;
        Task UpdateAsync<T>(string indexName, string id, T document) where T : class;
        Task DeleteAsync(string indexName, string id);
        Task<IEnumerable<T>> SearchAsync<T>(string indexName, string searchText) where T : class;
    }
}
