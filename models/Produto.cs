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
        public string Categoria { get; }

        // ...
        public decimal Preco { get; }
        public int Prioridade { get; }

        public Produto(string nome, string categoria, decimal preco, int prioridade)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            Prioridade = prioridade;
        }

        public override string ToString(){
            return $"{Nome, -30} R$ {Preco}";
            // return String.Format(s, Nome, Preco);
        }

        public bool IsSuperfluo
        {
            get
            {
                return Prioridade > 100;
            }
        }
        
    }

    public class SortCategoria : IComparer<Produto>
    {
        public int Compare(Produto x, Produto y)
        {
            return new CaseInsensitiveComparer().Compare(x.Categoria, y.Categoria);
        }
    }
    public class SortNome : IComparer<Produto>
    {
        public int Compare(Produto x, Produto y)
        {
            return new CaseInsensitiveComparer().Compare(x.Nome, y.Nome);
        }
    }
    public class SortPreco : IComparer<Produto>
    {
        public int Compare(Produto x, Produto y)
        {
            return Decimal.Compare(x.Preco, y.Preco);
        }
    }

    public class SortPrioridade : IComparer<Produto>
    {
        public int Compare(Produto x, Produto y)
        {
            return x.Prioridade - y.Prioridade;
        }
    }

    // Ordena todos os superfluos como maior que nao-superfluos.
    // Estabelece uma relacao entre preco e prioridade para os superfluos
    public class SortInteligente : IComparer<Produto>
    {
        public int Compare(Produto x, Produto y)
        {
            if(x.IsSuperfluo != y.IsSuperfluo)
                return x.Prioridade - y.Prioridade;
            decimal xvalue, yvalue;
            xvalue = x.IsSuperfluo ? ((x.Prioridade*2) + ((2 + x.Preco)/2)) : x.Prioridade;
            yvalue = y.IsSuperfluo ? ((y.Prioridade*2) + ((2 + y.Preco)/2)) : y.Prioridade;
            if(xvalue > yvalue)
                return 1;
            if(xvalue < yvalue)
                return -1;
            return 0; //xvalue == yvalue
        }
    }
}