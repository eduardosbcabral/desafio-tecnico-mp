using System;

namespace DesafioTecnicoMP
{
    public class CrawlerErrors
    {
        private static string[] errors = new string[]
        {
            "Deu erro!",
            "Erro na aplicação.",
            "Ocorreu um erro ao executar a operação"
        };

        public static string Random()
        {
            var random = new Random();
            return errors[random.Next(0, errors.Length)];
        }
    }
}
