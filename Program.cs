using System;
using Sistema_Vendas.Classes;
using System.IO;

namespace Sistema_Vendas
{
    class Program
    {
        static void Main(string[] args)
        {
            int ops = 0;
            while (ops != 5)
            {
                Console.WriteLine("Escolha uma das opções a baixo:");
                Console.WriteLine("1. Cadastrar produto");
                Console.WriteLine("2. Cadastrar cliente");
                Console.WriteLine("3. Editar estoque de produtos");
                Console.WriteLine("4. Realizar venda");
                Console.WriteLine("5. Sair");
                ops = Int32.Parse(Console.ReadLine());
                switch (ops)
                {
                    case 1:
                        Console.Clear();
                        Produto produto = new Produto();
                        produto.cadastroProduto(produto);
                        break;

                    case 2:
                        Console.Clear();
                        Cliente cliente = new Cliente();
                        cliente.cadastroCliente(cliente);
                        break;

                    case 3:
                        Console.Clear();
                        string[] produtos = File.ReadAllLines("C:\\Projetos\\Sistema-Vendas\\Arquivos\\produtos.txt");
                        Console.WriteLine("Produtos cadastrados: ");
                        foreach (var prod in produtos)
                        {
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            string[] p = prod.Split(";");
                            Console.WriteLine("ID: {0}", p[0]);
                            Console.WriteLine("Nome: {0}", p[1]);
                            Console.WriteLine("Quantidade no estoque: {0}", p[2]);
                        }
                        Console.WriteLine("Informe o ID do produto que deseja editar o estoque: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Informe a quantidade de itens que deseja adicionar ao estoque: ");
                        int quantidade = int.Parse(Console.ReadLine());

                        foreach (var prod in produtos)
                        {
                            string[] p = prod.Split(";");
                            if (int.Parse(p[0]) == id)
                            {
                                Produto produtoAtualizado = new Produto(int.Parse(p[0]), p[1], int.Parse(p[2]), float.Parse(p[3]), p[4]);
                                produtoAtualizado.setQuantidade(produtoAtualizado.getQuantidade() + quantidade);
                                produtoAtualizado.editarEstoque(produtos);
                                break;
                            }
                        }

                        Console.WriteLine("Estoque atualizado.");

                        break;
                        
                    case 4:
                        Console.Clear();
                        Venda venda = new Venda();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção incorreta. O aplicativo será encerrado.");
                        ops = 5;
                        break;
                }
            }
            
        }
    }
}
