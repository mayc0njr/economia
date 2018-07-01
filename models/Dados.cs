using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace economia.models
{
    class Dados
    {
        private static string csv = null;
        private static char ps = Path.DirectorySeparatorChar;
        public static string Csv
        {
            get
            {
                if (csv == null)
                {
                    return File.ReadAllText("res" + ps + "planilhaMercado.csv");
                }
                return csv;
            }
        }

        public static void printArray<T>(T[] t)
        {
            foreach (var item in t)
            {
            }
        }
        public static void InitializeProdutos()
        {
            List<Produto> mercado = new List<Produto>();
            var produtos = Csv.Split("\n");
            printArray<string>(produtos);
            var nome = produtos[0].Split(",");
            printArray<string>(nome);
            for (var x = 1; x < produtos.Length; x++)
            {
                var tipo = produtos[x];
                var produto = tipo.Split(",");
                for (var y = 1; y < produto.Length - 1; y++)
                {
                    Produto p = new Produto(produto[0] + " " + nome[y], produto[0], Decimal.Parse(produto[y]), Int32.Parse(produto[produto.Length - 1]));
                    Compra.Mercado.Add(p);
                }
            }
        }

        public static void Salvar(string texto)
        {
            File.WriteAllText($"res{ps}Compra{DateTime.Now}.txt", texto);
        }



    }
}
