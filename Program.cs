using System;
using Sistema_Vendas.Classes;
using System.IO;

namespace Sistema_Vendas
{
    class Program
    {
        static void Main(string[] args)
        {
            int ops;
            Console.WriteLine("Escolha uma das opções a baixo:");
            Console.WriteLine("1. Cadastrar produto");
            Console.WriteLine("2. Cadastrar cliente");
            Console.WriteLine("3. Realizar venda");
            ops = Int32.Parse(Console.ReadLine());
            switch (ops)
            {
                case 1:
                    Produto produto = new Produto();
                    produto.cadastroProduto(produto);
                    break;

                case 2:
                    Cliente cliente = new Cliente();
                    cliente.cadastroCliente(cliente);
                    break;

                case 3:
                    Venda venda = new Venda();
                    
                    // string[] produtos = File.ReadAllLines("C:\\Projetos\\Sistema-Vendas\\Arquivos\\produtos.txt");
                    // foreach (var p in produtos)
                    // {
                    //     Console.WriteLine(p.ToString());
                    // }

                    // string[] clientes = File.ReadAllLines("C:\\Projetos\\Sistema-Vendas\\Arquivos\\clientes.txt");
                    // foreach (var c in clientes)
                    // {
                    //     Console.WriteLine(c.ToString());
                    // }
                    break;

                default:
                    Console.WriteLine("Opção incorreta. O aplicativo será encerrado.");
                    break;
            }
            
        }
    }
}
