using System;
using System.Linq;

using System.Collections.Generic;

using economia.models;

namespace economia
{
    class Program
    {
        static void Main(string[] args)
        {
            // List<Produto> c = new List<Produto>();
            // Produto p = new Produto("Arroz Tipo 1", "Arroz", 12.00m);
            // c.Add(p);
            // p = new Produto("Feijao Tipo 1", "Feijao", 12);
            // c.Add(p);
            // p = new Produto("Arroz Tipo 2", "Arroz", 11);
            // c.Add(p);
            // p = new Produto("Feijao Tipo 2", "Feijao", 11);
            // c.Add(p);
            // p = new Produto("Arroz Tipo 3", "Arroz", 10);
            // c.Add(p);
            // p = new Produto("Feijao Tipo 3", "Feijao", 10);
            // c.Add(p);

            // Compra.Mercado.AddRange(c);
            Dados.InitializeProdutos();
        }
    }
}
