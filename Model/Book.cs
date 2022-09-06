using IAGROBooks_WebAPI.Helpers;
using Newtonsoft.Json;

namespace IAGROBooks_WebAPI.Model
{
    public class Book
    {
        public int Id { get; set; }      
        public string Name { get; set; }
        public double Price { get; set; }


        /// <summary>
        /// Precisei gerar este atributo como OBject pois o arquivo json fornecido contém valores usando o esquema par de chave e valor, com chaves contendo espaço.        
        /// </summary>
        public object Specifications { get; set; }

        /// <summary>
        /// Calcula o custo do frete na instância do objeto <br />
        /// Adicionei este atributo que calcula o valor do frete dentro da Classe livro, pois não foi específicado em qual momento deveria ser recuperado o valor do frete
        /// </summary>
        public double ShippingCost { get
            {
                return this.Price != null ? ShippingHelper.GetShippingCost(this.Price) : 0;
            } }
    }

    
}
