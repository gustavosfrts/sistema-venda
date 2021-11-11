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
                    FileStream produtoArquivo = new FileStream("C:\\Projetos\\Sistema-Vendas\\Arquivos\\produtos.txt", FileMode.Open, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(produtoArquivo);
                    string str1 = produto.getNome();
                    string str2 = produto.getQuantidade().ToString();
                    string str3 = produto.getPreco().ToString();
                    string str4 = produto.getTamanho();
                    
                    sw.WriteLine(str1);
                    sw.WriteLine(str2);
                    sw.WriteLine(str3);
                    sw.WriteLine(str4);
                    sw.Close();
                    produtoArquivo.Close();

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
