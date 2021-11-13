using System;
using System.IO;

namespace Sistema_Vendas.Classes
{
    class Cliente
    {
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

        public Cliente(string nome, string cpf, DateTime dataNascimento, string telefone)
        {
            this.setNome(nome);
            this.setCpf(cpf);
            this.setDataNascimento(dataNascimento);
            this.setTelefone(telefone);
        }

        public void cadastroCliente(Cliente cliente)
        {
            FileStream clienteArquivo = new FileStream("C:\\Projetos\\Sistema-Vendas\\Arquivos\\clientes.txt", FileMode.Append, FileAccess.Write);
            StreamWriter swCliente = new StreamWriter(clienteArquivo);

            string strCliente = cliente.getCpf() + ";" + cliente.getNome() + ";" + cliente.getTelefone() + ";" + cliente.getDataNascimento();
            swCliente.WriteLine(strCliente);
            swCliente.Close();
            clienteArquivo.Close();
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
