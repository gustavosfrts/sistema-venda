using System;
using System.IO;

namespace Sistema_Vendas.Classes
{
    class Venda
    {
        private int idProduto;
        private string clienteCpf;
        private float valor;
        public Venda()
        {
            // Pega o ID do produto e o CPF do cliente, para poder realizar a venda.
            Console.WriteLine("Informe o ID do Produto: ");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Informe o CPF do Cliente: ");
            string cpf = Console.ReadLine();
            // Inicia algumas variaveis de controle
            bool existeProduto = false;
            bool existeCliente = false;
            Produto produtoCadastrado = null;
            Cliente clienteCadastrado = null;
            // Traz as informações dos clientes e produtos cadastrados.
            string[] produtos = File.ReadAllLines("C:\\Projetos\\Sistema-Vendas\\Arquivos\\produtos.txt");
            string[] clientes = File.ReadAllLines("C:\\Projetos\\Sistema-Vendas\\Arquivos\\clientes.txt");

            // Verifica se o ID informado está associado para algum produto.
            foreach (var produto in produtos)
            {
                string[] p = produto.Split(";");
                if (int.Parse(p[0]) == id)
                {
                    existeProduto = true;
                    produtoCadastrado = new Produto(int.Parse(p[0]), p[1], int.Parse(p[2]), float.Parse(p[3]), p[4]);
                    break;
                }
            }

            // Verifica se o CPF informado está associado para algum cliente.
            foreach (var cliente in clientes)
            {
                string[] c = cliente.Split(";");
                if (c[0].ToString() == cpf)
                {
                    existeCliente = true;
                    clienteCadastrado = new Cliente(c[1], c[0], Convert.ToDateTime(c[3]), c[2]);
                    break;
                }
            }

            // Caso exista o ID e o CPF cadastrado, faz o processo de venda.
            if (existeProduto && existeCliente)
            {
                // Verifica se possui estoque do produto.
                if(produtoCadastrado.getQuantidade() > 0)
                {
                    // Pergunta a quantidade daquele produto que será comprado.
                    Console.WriteLine("Informe a quantidade que deseja comprar deste produto (Estoque: {0})", produtoCadastrado.getQuantidade());
                    int qtd = int.Parse(Console.ReadLine());
                    // Verificação para nao permitir comprar mais do que possui no estoque.
                    while (qtd <= 0 || qtd > produtoCadastrado.getQuantidade())
                    {
                        Console.WriteLine("Quantidade maior que possuímos no estoque. Insira um novo valor. (Estoque: {0})", produtoCadastrado.getQuantidade());
                        qtd = int.Parse(Console.ReadLine());
                    }
                    // Controle de estoque.
                    produtoCadastrado.setQuantidade(produtoCadastrado.getQuantidade() - qtd);

                    // Salva as informações da venda no objeto de venda.
                    this.setClienteCpf(clienteCadastrado.getCpf());
                    this.setIdProduto(produtoCadastrado.getId());
                    this.setValor(produtoCadastrado.getPreco() * qtd);

                    // Salva as informaçoes de venda no arquivo.
                    FileStream vendaArquivo = new FileStream("C:\\Projetos\\Sistema-Vendas\\Arquivos\\vendas.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter swVenda = new StreamWriter(vendaArquivo);
                    
                    string strVenda = this.getIdProduto() + ";" + this.getClienteCpf() + ";" + this.getValor();
                    swVenda.WriteLine(strVenda);
                    swVenda.Close();
                    vendaArquivo.Close();

                    // Atualiza o estoque do produto apos a venda no arquivo.
                    string[] strProdutos = new string[produtos.Length];
                    
                    for (int i = 0; i <= produtos.Length-1; i++)
                    {
                        string[] p = produtos[i].Split(";");
                        if (int.Parse(p[0]) == this.getIdProduto())
                        {
                            strProdutos[i] = produtoCadastrado.getId() + ";" + produtoCadastrado.getNome() + ";" + produtoCadastrado.getQuantidade() + ";" + produtoCadastrado.getPreco() + ";" + produtoCadastrado.getTamanho();
                        }
                        else
                        {
                            strProdutos[i] = produtos[i];
                        }
                    }

                    File.WriteAllText("C:\\Projetos\\Sistema-Vendas\\Arquivos\\produtos.txt", "");
                    FileStream produtoArquivo = new FileStream("C:\\Projetos\\Sistema-Vendas\\Arquivos\\produtos.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter swProduto = new StreamWriter(produtoArquivo);
                    foreach (var p in strProdutos)
                    {    
                        swProduto.WriteLine(p);
                    }
                    swProduto.Close();
                    produtoArquivo.Close();
                    
                    Console.WriteLine("Venda realizada com sucesso!");

                }
            }
            else
            {
                Console.WriteLine("Não foi encontrado nenhum produto/cliente. Por favor, tente novamente mais tarde.");
            }
        }
        public int getIdProduto()
        {
            return this.idProduto;
        }
        public void setIdProduto(int id)
        {
            this.idProduto = id;
        }
        public string getClienteCpf()
        {
            return this.clienteCpf;
        }
        public void setClienteCpf(string cpf)
        {
            this.clienteCpf = cpf;
        }
        public float getValor()
        {
            return this.valor;
        }
        public void setValor(float valor)
        {
            this.valor = valor;
        }
    }
}
