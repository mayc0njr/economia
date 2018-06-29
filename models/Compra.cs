using System.Collections.Generic;
using System.Linq;

namespace economia
{
    public class Compra
    {
        public decimal CustoMaximo { get ; set; }

        public List<Produto> Compras { get; set; }

        public Compra(decimal custoMaximo, List<Produto> produtos){
            CustoMaximo = custoMaximo;
            Compras = new List<Produto>();
            foreach (var item in produtos)
            {
                Compras.Add(item);
            }
        }
        // Varargs aqui,
        // Passa quantos parametros do tipo Produto quiser.
        public Compra(decimal custoMaximo, params Produto[] produtos)
        {
            CustoMaximo = custoMaximo;
            Compras = new List<Produto>();
            foreach (var item in produtos)
            {
                Compras.Add(item);
            }
        }

        // Calcula o preco total da compra.
        public decimal Total() {
            return Compras.Sum(item => item.Preco);
        }


        // Filtra por categoria.
        public List<Produto> Filter(string categoria){
            return Compras.Where(item => item.Categoria.Equals(categoria)).ToList();
        }
    }
}