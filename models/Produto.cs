using System;
using System.Collections;

namespace economia
{
    public class Produto
    {
        //Nome completo do produto, sendo "Categoria + Tipo" Ex: Arroz Tipo A
        public string Nome { get; }
        //Categoria ou tipo de produto, Ex: Arroz, Feijao, etc.
        public string Categoria { get; private set; }

        // ...
        public decimal Preco { get; }

        public Produto(string nome, string categoria, decimal preco)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
        }

        public override string ToString(){
            return "Produto: " + Nome + "\nR$: " + Preco;
        }
    }

    public class SortCategoria : IComparer
    {
        public int Compare(object x, object y)
        {
            var p1 = x as Produto;
            var p2 = y as Produto;
            return new CaseInsensitiveComparer().Compare(p1.Categoria, p2.Categoria);
        }
    }
    public class SortPreco : IComparer
    {
        public int Compare(object x, object y)
        {
            var p1 = x as Produto;
            var p2 = y as Produto;
            return new CaseInsensitiveComparer().Compare(p1.Preco, p2.Preco);
        }
    }
}