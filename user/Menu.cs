using System;
using System.Collections.Generic;
using System.Linq;

using economia.models;

namespace economia.user
{
    public class Menu
    {
        static int escolha, quantidade;
        static Compra compra;
        public static List<Produto> Mercado
        {
            get
            {
                return Compra.Mercado;
            }
        }
        public static decimal formatDecimal(string s)
        {
            var str = s;
            if(s.Contains(','))
                s.Replace(',','.');
            if(!s.Contains('.'))
            {
                str += ".00";
            }
            else
            {
                str += "00";
            }
            str = String.Format("{0:F2}", str);
            return Helper.ParseDecimal(str);
            // Console.WriteLine(dec.ToString("0.##"));
            // return Decimal.Parse(dec.ToString("0.##"));
            
        }
        public static void MenuInicial()
        {
            //Carrega mercado aqui...


            Console.Write("Digite o valor máximo que deseja gastar: ");
            decimal custo = 0;
            string read;
            while(true)
            {
                read = Console.ReadLine();
                if(custo < 0)
                    Console.WriteLine("Digite um valor maior que 0!");
                else
                {
                    custo = formatDecimal(read);
                    break;
                }
            };
            Console.WriteLine("Custo Máximo Desejado: " + custo);
            compra = new Compra(custo);
            menuAlteracao(compra);
        }
        public static void menuAlteracao(Compra compra)
        {
            escolha=0;
            while(true)
            {
                Console.WriteLine("\nO que você deseja fazer?");
                Console.WriteLine("1. Inserir Produto.");
                Console.WriteLine("2. Remover Produto.");
                Console.WriteLine("3. Gerar Sugestões");
                Console.WriteLine("4. Imprimir Compra Atual.");
                Console.WriteLine("5. Imprimir e Sair");
                Console.Write("Opção: ");
                escolha = Int32.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        AddProdutos(compra);
                        break;
                    case 2:
                        RemoveProdutos(compra);
                        break;
                    case 3:
                        GerarSugestoes(compra);
                        break;
                    case 4:
                        Console.WriteLine(compra);
                        break;
                    case 5:
                        goto endwhilema;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            }
            endwhilema:
            Save(compra);

        }
        //Imprime uma lista recebida por parametro
        public static void ImprimeLista(List<Produto> lista, bool index=true)
        {
            if(index)
            {
                for(var x=0 ; x<lista.Count ; x++)
                {
                    Console.WriteLine("[{0}] {1}", x, lista[x]);
                }
            }
            else
            {
                for(var x=0 ; x<lista.Count ; x++)
                {
                    Console.WriteLine("{0}", lista[x]);
                }
            }
            Console.WriteLine("Total: R$ {0}", lista.Sum(item => item.Preco));
        }

        //Pergunta se aceita sugestao e retorna verdadeiro ou falso.
        public static bool AceitarSugestao(){
            while(true)
            {
                Console.WriteLine("\nDeseja aceitar a sugestão?");
                Console.WriteLine("1. Sim");
                Console.WriteLine("2. Não");
                Console.Write("Opção: ");
                escolha = Int32.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        return true;
                    case 2:
                        return false;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            }
        }
        public static void GerarSugestoes(Compra compra)
        {
            while(true)
            {
                escolha=0;
                Console.WriteLine("\n1. Solução Boa*: Troca produtos por mais baratos até que a compra esteja abaixo do custo maximo");
                Console.WriteLine("   ou todos produtos sejam os mais baratos");
                Console.WriteLine("2. Solução Barata*: Troca produtos por mais baratos até que todos estejam com o preço mais baixo");
                Console.WriteLine("   possível.");
                Console.WriteLine("3. Solução Super-barata: Remove todos os produtos considerados supérfluos e troca todos os produtos");
                Console.WriteLine("   pelos mais baratos");
                Console.WriteLine("   *: As soluções boa e barata, removerão produtos supérfluos se o custo estiver acima do custo máximo");
                Console.WriteLine("   desejado.");
                Console.WriteLine("4. Imprimir Compra Atual.");
                Console.WriteLine("5. Voltar\n");
                Console.Write("Opção: ");
                escolha = Int32.Parse(Console.ReadLine());
                switch(escolha)
                {
                    case 1:
                        var sugestao = compra.MelhorarCusto();
                        ImprimeLista(sugestao);
                        if(AceitarSugestao())
                            compra.Compras = sugestao;
                        break;
                    case 2:
                        var sugestaoM = compra.MelhorCustoPossivel();
                        ImprimeLista(sugestaoM);
                        if(AceitarSugestao())
                            compra.Compras = sugestaoM;
                        break;
                    case 3:
                        var sugestaoS = compra.MelhorCustoPossivel(true);
                        ImprimeLista(sugestaoS);
                        if(AceitarSugestao())
                            compra.Compras = sugestaoS;
                        break;
                    case 4:
                        Console.WriteLine(compra);
                        break;
                    case 5:
                        goto endwhilegs;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            }
                endwhilegs:
                Console.WriteLine("Voltando ao menu da compra.\n");
                return;
        }
        public static void Save(Compra compra)
        {
            var arquivo = Dados.Salvar(compra.ToString());
            Console.WriteLine($"Dados impresso em '{arquivo}'");
        }
        //Adiciona Produtos na lista de compras.
        public static void RemoveProdutos(Compra compra)
        {
            escolha=0;
            quantidade=0;
            while(true){
                for(var x=0 ; x < compra.Compras.Count ; x++)
                {
                    Console.WriteLine("[{0}] - {1}", x, compra.Compras[x]);
                }
                Console.WriteLine("Deseja remover qual produto?");
                Console.Write("[-1] - Voltar\nOpção: ");
                escolha = Int32.Parse(Console.ReadLine());
                if(escolha == -1)
                    break;
                else if(escolha < -1 || escolha >= compra.Compras.Count)
                    Console.WriteLine("Produto não encontrado.");
                else
                {
                    Console.WriteLine(compra.Compras[escolha]);
                    Console.Write("Digite a quantidade: ");
                    quantidade = int.Parse(Console.ReadLine());
                    if(quantidade < 0) quantidade = 0;
                    var qremove = 0;
                    var premove = compra.Compras[escolha];
                    for(var x=0 ; x < quantidade ; x++)
                    {
                        var removeu = compra.Compras.Remove(premove);
                        if(removeu)
                            qremove++;
                        else
                            break;
                    }
                    Console.WriteLine("Removido ({1}) {0}!\n", premove, qremove);
                }
            }
        }
        //Adiciona produtos na lista de compras.
        public static void AddProdutos(Compra compra)
        {
            escolha=0;
            quantidade=0;
            while(true){
                for(var x=0 ; x < Mercado.Count ; x++)
                {
                    Console.WriteLine("[{0}] - {1}", x, Mercado[x]);
                }
                Console.WriteLine("Deseja adicionar qual produto?");
                Console.Write("[-1] - Voltar\nOpção: ");
                escolha = Int32.Parse(Console.ReadLine());
                if(escolha == -1)
                    break;
                else if(escolha < -1 || escolha >= Mercado.Count)
                    Console.WriteLine("Produto não encontrado.");
                else
                {
                    Console.WriteLine(Mercado[escolha]);
                    Console.Write("Digite a quantidade: ");
                    quantidade = int.Parse(Console.ReadLine());
                    if(quantidade < 0) quantidade = 0;
                    for(var x=0 ; x < quantidade ; x++)
                        compra.Compras.Add(Mercado[escolha]);
                    Console.WriteLine("Adicionado ({1}) {0}!\n", Mercado[escolha].Nome, quantidade);
                }
            }
        }
    }
}