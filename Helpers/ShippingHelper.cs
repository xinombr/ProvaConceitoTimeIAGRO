namespace IAGROBooks_WebAPI.Helpers
{

    /// <summary>
    /// Realiza calculos de frete dos livros
    /// </summary>
    public static class ShippingHelper
    {
        /// <summary>
        /// Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double GetShippingCost(double bookvalue)
        {
           return (double)bookvalue * 20 / 100;
        }
    }
}
