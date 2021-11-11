using System;

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
            Console.WriteLine("Informe o nome do produto: ");
            this.setNome(Console.ReadLine());
            Console.WriteLine("Informe a quantidade de produtos a serem inseridos: ");
            this.setQuantidade(Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Informe o preço do produto: ");
            this.setPreco(float.Parse(Console.ReadLine()));
            Console.WriteLine("Informe o tamanho da roupa: ");
            this.setTamanho(Console.ReadLine());
        }
        public void setId()
        {
            this.id = 1;
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
