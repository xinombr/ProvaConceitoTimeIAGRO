using IAGROBooks_WebAPI.Model;

namespace IAGROBooks_WebAPI.Repository.Abstract
{

    /// <summary>
    /// Implementado padrão de arquitetura Repository
    /// </summary>
    public interface IBookRepository
    {

        /// <summary>
        /// Retorna um ou mais livros que contenham o termo informado no parâmetro e ordenados pelo parâmetro orderByPrice
        /// Que seja possível buscar livros por suas especificações(autor, nome do livro ou outro atributo)
        /// </summary>
        /// <param name="term"></param>
        /// <param name="orderByPrice"></param>
        /// <returns></returns>
        public  Task<IEnumerable<Book>> GetAsync(string term, string orderByPrice);
    }
}
