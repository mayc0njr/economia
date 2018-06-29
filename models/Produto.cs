using System;

namespace economia
{
    public class Produto
    {
        public string Nome { get; }
        public string Categoria { get; private set; }
        public decimal Preco { get; }

        public Produto(string nome, string categoria, decimal preco)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
        }

        public override string ToString(){
            return Nome;
        }
    }
}