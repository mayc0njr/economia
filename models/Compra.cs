using System.Collections.Generic;
using System.Linq;


namespace economia.models
{
    public class Compra
    {
        public decimal CustoMaximo { get ; set; }

        public static List<Produto> Mercado { get; } = 
            Mercado = new List<Produto>();

        public List<Produto> Compras { get; set; }

        public decimal CustoTotal
        {
            get
            {
                return Compras.Sum(item => item.Preco);
            }
        }

        public Compra(decimal custoMaximo, List<Produto> produtos){
            CustoMaximo = custoMaximo;
            Compras = new List<Produto>();
            produtos.ForEach(Compras.Add);
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
        public List<Produto> Filter(List<Produto> lista, string categoria){
            return lista.Where(item => item.Categoria.Equals(categoria)).ToList();
        }
        
        public List<Produto> RemoveSuperfluos(List<Produto> compra, bool superbarato = false)
        {
            System.Console.WriteLine("Removendo superfluos.");
            List<Produto> superfluos = compra.Where(item => item.IsSuperfluo).ToList();
            List<Produto> obrigatorio = compra.Where(item => !item.IsSuperfluo).ToList();
            var copia = new List<Produto>();
            copia.AddRange(compra);
            if(superbarato)
                return obrigatorio;
            while(copia.Sum(item => item.Preco) > CustoMaximo)
            {
            System.Console.WriteLine("LOOP: " + copia.Sum(item => item.Preco) + "  CustoMaximo: " + CustoMaximo);
                var copiaTemp = copia.OrderByDescending(item => item.Prioridade).ToList();
                copia.Remove(copiaTemp[0]);
            }
            return copia;
        }
        public List<Produto> MelhorarCusto(bool melhorPossivel = false, bool superbarato = false){
            var compras = Compras;
            var custoMaximo = CustoMaximo;
            //Ordenando por Categoria, e itens de mesma categoria por preco.
            var copia = compras.OrderByDescending(item => item.Preco).OrderBy(item => item.Categoria).ToList();
            var categoria = "";
            List<Produto> mercado = null;
            var alterou = false; //Se der uma iteração sem alterar nada, para de remover e retorna;
            do
            {
                alterou = false;
                for(var x=0 ; x < copia.Count ; x++)
                {
                    if(!melhorPossivel && copia.Sum(i => i.Preco) < custoMaximo)
                        break;
                    var item = copia[x];
                    if(categoria != item.Categoria){
                        mercado = Filter(Mercado, item.Categoria);
                        //Lista de produtos da categoria do produto atual ordenada decrescente pelo preco.
                        mercado = mercado.OrderBy(i => i.Preco).Reverse().ToList();
                        categoria = item.Categoria;
                    }
                    foreach (var p in mercado)
                    {
                        if(p.Preco < item.Preco)
                        {
                            copia[x] = p;
                            alterou = true;
                            break;
                        }
                    }
                }
            }while(alterou);
            copia = RemoveSuperfluos(copia, superbarato);
            return copia;
        }
        public List<Produto> MelhorCustoPossivel(bool superbarato = false){
            return MelhorarCusto(true, superbarato);
        }
    }
}