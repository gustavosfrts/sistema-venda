using System;
using Sistema_Vendas.Classes;

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
                    break;
                case 2:
                    Cliente cliente = new Cliente();
                    break;
                case 3:
                    Venda venda = new Venda();
                    break;
                default:
                    Console.WriteLine("Opção incorreta. O aplicativo será encerrado.");
                    break;
            }
            
        }
    }
}
