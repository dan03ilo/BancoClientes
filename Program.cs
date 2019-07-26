using System;
using System.Collections.Generic;
using BancoClientes.domain;

namespace BancoClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instância da classe cliente
             Cliente cli = new Cliente();
            Console.Clear();
            // Console.WriteLine("Digite o nome do cliente");
            // cli.nome = Console.ReadLine();

            // Console.WriteLine("Digite o email do cliente");
            // cli.email = Console.ReadLine();

            // Console.WriteLine("Digite o telefone do cliente");
            // cli.telefone = Console.ReadLine();

            // Console.WriteLine("Digite a idade do cliente");
            // cli.idade = int.Parse(Console.ReadLine());

            // Console.WriteLine(cli.cadastrar());

            List<Cliente> rs = cli.list();

            for(int i = 0; i < rs.Count; i++){
                Console.WriteLine(rs[i].id+"\t"+rs[i].idade);
            }    
        }
    }
}
