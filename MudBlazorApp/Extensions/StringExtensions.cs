using System.Text.RegularExpressions;

namespace MudBlazorApp.Extensions
{
    public static class StringExtensions //Aqui nessa classe, tenho um método que retira os caracteres especiais da string e retorna só os caracteres
    {
        public static string SomenteCaracteres(this string input) 
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string pattern = @"[-\.\(\)\s]";

            var result = Regex.Replace(input, pattern, string.Empty);

            return result;
        }
    }
}
