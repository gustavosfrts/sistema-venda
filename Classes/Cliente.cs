using System;

namespace Sistema_Vendas.Classes
{
    class Cliente
    {
        private int id;
        private string nome;
        private string cpf;
        private DateTime dataNascimento;
        private string telefone;

        public Cliente(){
            Console.WriteLine("Por favor, informe seu nome: ");
            this.setNome(Console.ReadLine());
            Console.WriteLine("Por favor, informe seu CPF: ");
            this.setCpf(Console.ReadLine());
            Console.WriteLine("Por favor, informe sua data de nascimento: ");
            this.setDataNascimento(DateTime.Parse(Console.ReadLine()));
            Console.WriteLine("Por favor, informe seu telefone: ");
            this.setTelefone(Console.ReadLine());
        }

        public string getNome()
        {
            return this.nome;
        }
        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getCpf()
        {
            return this.cpf;
        }

        public void setCpf(string cpf)
        {
            this.cpf = cpf;
        }

        public DateTime getDataNascimento()
        {
            return this.dataNascimento;
        }

        public void setDataNascimento(DateTime dataNascimento)
        {
            this.dataNascimento = dataNascimento;
        }

        public string getTelefone()
        {
            return this.telefone;
        }

        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }
    }
}
