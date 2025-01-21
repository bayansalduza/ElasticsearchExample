using Microsoft.Extensions.Options;
using Nest;

namespace ElasticsearchExample.ElasticsearchService.Services
{
    public class ElasticsearchService : IElasticsearchService
    {
        private readonly ElasticClient _elasticClient;


        public ElasticsearchService(IOptions<ElasticsearchOptions> options)
        {
            var esOptions = options.Value;

            var settings = new ConnectionSettings(new Uri(esOptions.Url))
                .DefaultIndex(esOptions.DefaultIndex);

            _elasticClient = new ElasticClient(settings);
        }

        public async Task CreateIndexIfNotExistsAsync(string indexName)
        {
            var existsResponse = await _elasticClient.Indices.ExistsAsync(indexName);
            if (!existsResponse.Exists)
            {
                await _elasticClient.Indices.CreateAsync(indexName, c => c
                    .Map(m => m.AutoMap())
                );
            }
        }

        public async Task InsertAsync<T>(string indexName, T document) where T : class
        {
            var response = await _elasticClient.IndexAsync(document, i => i.Index(indexName));
        }

        public async Task<T> GetByIdAsync<T>(string indexName, string id) where T : class
        {
            var response = await _elasticClient.GetAsync<T>(id, g => g.Index(indexName));
            return response.Source;
        }

        public async Task UpdateAsync<T>(string indexName, string id, T document) where T : class
        {
            await _elasticClient.UpdateAsync<T>(id, u => u
                .Index(indexName)
                .Doc(document));
        }

        public async Task DeleteAsync(string indexName, string id)
        {
            await _elasticClient.DeleteAsync(new DeleteRequest(indexName, id));
        }

        public async Task<IEnumerable<T>> SearchAsync<T>(string indexName, string searchText) where T : class
        {
            var response = await _elasticClient.SearchAsync<T>(s => s
                .Index(indexName)
                .Query(q => q
                    .QueryString(qs => qs
                        .Query($"*{searchText}*")
                    )
                )
            );
            return response.Documents;
        }
    }
}
