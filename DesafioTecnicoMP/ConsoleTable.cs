using System;

namespace DesafioTecnicoMP
{
    public class ConsoleTable
    {
        private readonly int _tableWidth;

        public ConsoleTable(int tableWidth)
        {
            _tableWidth = tableWidth;
            Console.WriteLine("Imprimindo o relatório...");
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', _tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (_tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
