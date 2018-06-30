using System;
using System.Linq;

namespace economia
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto("Arroz Tipo 1", "Arroz", 12);
            Compra c = new Compra(50);
            c.Compras.Add(p);
            p = new Produto("Feijao Tipo 1", "Feijao", 12);
            c.Compras.Add(p);
            p = new Produto("Arroz Tipo 2", "Arroz", 11);
            c.Compras.Add(p);
            p = new Produto("Feijao Tipo 2", "Feijao", 11);
            c.Compras.Add(p);
            p = new Produto("Arroz Tipo 3", "Arroz", 10);
            c.Compras.Add(p);
            p = new Produto("Feijao Tipo 3", "Arroz", 10);
            c.Compras.Add(p);
            Console.WriteLine("Compra: " );
            c.Compras.ForEach(Console.WriteLine);
            Console.WriteLine("Filtro Arroz: ");
            c.Filter(c.Compras,"Arroz").ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    }
}
