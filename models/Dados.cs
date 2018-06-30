using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace economia.models
{
    class Dados
    {
        private static string csv = null;
        public static string Csv
        {
            get{
                if(csv == null)
                {
                    var s = Path.DirectorySeparatorChar;
                    return File.ReadAllText("res" + s + "planilhaMercado.csv");
                }
                return csv;
            }
        }

        public static void InitializeProdutos(){
            List<Produto> mercado = new List<Produto>();
            var produtos = Csv.Split("\n");
            var nome = produtos[0].Split(",");
            for(var x=1 ; x < produtos.Length ; x++)
            {
                var tipo = produtos[x];
                var produto = tipo.Split(",");
                for(var y=0 ; y < produto.Length-1 ; y++)
                {
                    var preco = produto[y] + 'm';
                    Produto p = new Produto(produto[0] + " " + nome[y], produto[0], Decimal.Parse(preco), Int32.Parse(produto[produto.Length-1]));
                    mercado.Add(p);
                }
            }
            mercado.ForEach(Console.WriteLine);
        }

        
        
    }
}
