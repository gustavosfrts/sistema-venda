using System;
using System.IO;

namespace Sistema_Vendas.Classes
{
    class Produto
    {
        private int id;
        private string nome;
        private int quantidade;
        private float preco;
        private string tamanho;
        public Produto()
        {
            Console.WriteLine("Informe o ID do produto: ");
            this.setId(Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Informe o nome do produto: ");
            this.setNome(Console.ReadLine());
            Console.WriteLine("Informe a quantidade de produtos a serem inseridos: ");
            this.setQuantidade(Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Informe o preço do produto: ");
            this.setPreco(float.Parse(Console.ReadLine()));
            Console.WriteLine("Informe o tamanho da roupa: ");
            this.setTamanho(Console.ReadLine());
        }

        public Produto(int id, string nome, int quantidade, float preco, string tamanho)
        {
            this.setId(id);
            this.setNome(nome);
            this.setQuantidade(quantidade);
            this.setPreco(preco);
            this.setTamanho(tamanho);
        }

        public void cadastroProduto(Produto produto)
        {
            FileStream produtoArquivo = new FileStream("C:\\Projetos\\Sistema-Vendas\\Arquivos\\produtos.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swProduto = new StreamWriter(produtoArquivo);
            
            string strProduto = produto.getId() + ";" + produto.getNome() + ";" + produto.getQuantidade() + ";" + produto.getPreco() + ";" + produto.getTamanho();
            swProduto.WriteLine(strProduto);
            swProduto.Close();
            produtoArquivo.Close();
        }

        public void editarEstoque(string[] produtos)
        {
            string[] strProdutos = new string[produtos.Length];
                    
            for (int i = 0; i <= produtos.Length-1; i++)
            {
                string[] p = produtos[i].Split(";");
                if (int.Parse(p[0]) == this.getId())
                {
                    strProdutos[i] = this.getId() + ";" + this.getNome() + ";" + this.getQuantidade() + ";" + this.getPreco() + ";" + this.getTamanho();
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
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return this.id;
        }
        public string getNome()
        {
            return this.nome;
        }
        public void setNome(string nome)
        {
            this.nome = nome;
        }
        public int getQuantidade()
        {
            return this.quantidade;
        }
        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }
        public float getPreco()
        {
            return this.preco;
        }
        public void setPreco(float preco)
        {
            this.preco = preco;
        }
        public string getTamanho()
        {
            return this.tamanho;
        }
        public void setTamanho(string tamanho)
        {
            this.tamanho = tamanho;
        }
    }
}
