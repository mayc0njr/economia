namespace economia
{
    public class Produto
    {
        public string Nome { get; }
        public decimal Preco { get; }
        public int Votos { get; private set; }
        public decimal Media { get; private set; }

        public Produto(string nome, decimal preco, int votos=0, decimal media=0)
        {
            Nome = nome;
            Preco = preco;
            Votos = votos;
            Media = media;
        }

        public decimal Avaliar(decimal media)
        {
            var result = (media + (Votos * this.Media))/(Votos+1);
            Media = result;
            Votos+=1;

            return result;
        }
    }
}