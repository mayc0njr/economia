using System;
using System.Collections;
using System.Collections.Generic;

namespace economia.models
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

    public class SortCategoria : IComparer<Produto>
    {
        public int Compare(Produto x, Produto y)
        {
            return new CaseInsensitiveComparer().Compare(x.Categoria, y.Categoria);
        }
    }
    public class SortPreco : IComparer<Produto>
    {
        public int Compare(Produto x, Produto y)
        {
            return new CaseInsensitiveComparer().Compare(x.Preco, y.Preco);
        }
    }
}