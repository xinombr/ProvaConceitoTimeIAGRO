using IAGROBooks_WebAPI.Model;
using IAGROBooks_WebAPI.Repository.Abstract;
using IAGROBooks_WebAPI.Repository.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq;

namespace IAGROBooks_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }


        /// <summary>
        /// Retorna a lista de livros de acordo o parametro informado <br />
        /// Pode ser pesquisada qualquer informa��o do livro, seja: Nome, Autor, Ilustradores, G�nero, etc
        /// </summary>
        /// <param name="term"></param>
        /// <param name="orderByPrice"></param>
        /// <returns></returns>        
        [HttpGet(Name = "GetBooks")]
        public async Task<IActionResult> GetAsync(string? term, string? orderByPrice)
        {
            //Valida se o termo de ordena��o orderByPrice est� correto, caso contr�rio, retorna bad request
            if (!string.IsNullOrEmpty(orderByPrice))
            {
               if (!orderByPrice.Equals("asc", StringComparison.OrdinalIgnoreCase) &
                   !orderByPrice.Equals("desc", StringComparison.OrdinalIgnoreCase)) return BadRequest();
            }             
            
            var result = await _bookRepository.GetAsync(term, orderByPrice);

            if (result.Count() == 0)
            {
                return NoContent();
            }
            
            return Ok(result);

        }
    }
}