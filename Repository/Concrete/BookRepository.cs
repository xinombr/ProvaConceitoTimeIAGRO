using IAGROBooks_WebAPI.Helpers;
using IAGROBooks_WebAPI.Model;
using IAGROBooks_WebAPI.Repository.Abstract;
using Newtonsoft.Json;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace IAGROBooks_WebAPI.Repository.Concrete
{

    public class BookRepository : IBookRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        //URL RAW do repositório fornecido para o test apontando para o arquivo Json
        private const string _booksUrl = "https://raw.githubusercontent.com/timeiagro/ProvaConceitoTimeIAGRO/main/books.json";

        public BookRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Book>> GetAsync(string term, string orderByPrice)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = await httpClient.GetFromJsonAsync<IEnumerable<Book>>(_booksUrl);
                

                //filtrar lista usando qualquer termo e ordenar  sem uso de framework, usando apenas linQ
                if(!string.IsNullOrEmpty(term))
                {
                    result = result.Where(b => b.Name.Contains(term, StringComparison.OrdinalIgnoreCase) |
                    b.Specifications.ToString().Contains(term, StringComparison.OrdinalIgnoreCase)

                    ); ;
                }

                
               
                if (!string.IsNullOrEmpty(orderByPrice)  && orderByPrice.Equals("asc", StringComparison.OrdinalIgnoreCase)) return result.OrderBy(r => r.Price);
                if (!string.IsNullOrEmpty(orderByPrice)  && orderByPrice.Equals("desc", StringComparison.OrdinalIgnoreCase)) return result.OrderByDescending(r => r.Price);
                
                return result;
            }
            catch
            {
                throw new Exception() ;
            }

        }
    }
}
