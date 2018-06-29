namespace economia
{
    public class Compra
    {
        public Produto Produto { get; }
        public int Quantidade { get; set; }

        public Compra(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }

        public decimal Total {
            get{
                return Produto.Preco * Quantidade;
            }
        }
    }
}