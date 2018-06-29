using System;
using System.Linq;

namespace economia
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto("Arroz Tipo 1", "Arroz", 10.50m);
            Compra c = new Compra(50);
            c.Compras.Add(p);
            p = new Produto("Feijao Tipo 1", "Feijao", 11);
            c.Compras.Add(p);
            p = new Produto("Arroz Tipo 2", "Arroz", 12);
            c.Compras.Add(p);
            p = new Produto("Feijao Tipo 2", "Feijao", 14);
            c.Compras.Add(p);
            p = new Produto("Arroz Tipo 3", "Arroz", 13);
            c.Compras.Add(p);
            Console.WriteLine("Compra: " );
            c.Compras.ForEach(Console.WriteLine);
            Console.WriteLine("Filtro Arroz: ");
            c.Filter("Arroz").ForEach(Console.WriteLine);
        }
    }
}
