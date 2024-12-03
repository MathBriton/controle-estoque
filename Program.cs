using System;
using System.Collections.Generic;

namespace ControleDeEstoqueConsole
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Quantidade: {Quantidade} | Preço: {Preco:C}";
        }
    }

    public class SistemaEstoque
    {
        private List<Produto> produtos = new List<Produto>();
        private int proximoId = 1;

        public void AdicionarProduto(string nome, int quantidade, decimal preco)
        {
            var produto = new Produto
            {
                Id = proximoId++,
                Nome = nome,
                Quantidade = quantidade,
                Preco = preco
            };

            produtos.Add(produto);
            Console.WriteLine("Produto adicionado com sucesso!");
        }

        public void ListarProdutos()
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }

        public void AtualizarQuantidade(int id, int novaQuantidade)
        {
            var produto = produtos.Find(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            produto.Quantidade = novaQuantidade;
            Console.WriteLine("Quantidade atualizada com sucesso!");
        }

        public void RemoverProduto(int id)
        {
            var produto = produtos.Find(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sistema = new SistemaEstoque();
            string opcao;

            do
            {
                Console.WriteLine("\n=== Sistema de Controle de Estoque ===");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Atualizar Quantidade");
                Console.WriteLine("4. Remover Produto");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite o nome do produto: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite a quantidade inicial: ");
                        int quantidade = int.Parse(Console.ReadLine());
                        Console.Write("Digite o preço do produto: ");
                        decimal preco = decimal.Parse(Console.ReadLine());

                        sistema.AdicionarProduto(nome, quantidade, preco);
                        break;

                    case "2":
                        sistema.ListarProdutos();
                        break;

                    case "3":
                        Console.Write("Digite o ID do produto para atualizar: ");
                        int idAtualizar = int.Parse(Console.ReadLine());
                        Console.Write("Digite a nova quantidade: ");
                        int novaQuantidade = int.Parse(Console.ReadLine());

                        sistema.AtualizarQuantidade(idAtualizar, novaQuantidade);
                        break;

                    case "4":
                        Console.Write("Digite o ID do produto para remover: ");
                        int idRemover = int.Parse(Console.ReadLine());
                        sistema.RemoverProduto(idRemover);
                        break;

                    case "5":
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (opcao != "5");
        }
    }
}
