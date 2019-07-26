using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BancoClientes.domain
{
    public class Cliente
    {
        //Atributos da classe
        public int id;
        public string nome;
        public string email;
        public string telefone;
        public int idade;
        public DateTime datacadastro;

        public string cadastrar(){
            //Criação da variável msg para nos ajudar a retornar uma mensagem de cadastro
            //realizado com sucesso ou não
            string msg = "";

            /*Vamos chamar as classes do MySql para estabelecer a comunicação com o banco de dados e realizar os comandos de 
              CRUD na tabela clientes.

              Utilizaremos a classe do MySqlConnection para nos ajudar a estabelecer a comunicação com  o servidor de banco de dados.
              Nesta classe você deve passar os seguintes itens:
                -Endereço do servidor de banco de dados(localhost|127.0.0.1)
                -Porta de comunicação(3306|3307)
                -Nome do banco de dados(cliente)
                -Nome do usuário(root)
                -Senha(Não tem)
             */
             MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=dbcliente;User Id=root;Password=");
             //Vamos abrir o banco de dados com o comando open
             conexao.Open();

              /*
              Vamos fazer uma instância da classe MySqlCommand. Essa classe nos ajuda a executar os comandos
              do sql no banco de de dados. Portanto se você quer realizar um insert na tabela, utilizará uma instância do comando
              MySqlCommand
               */         
               MySqlCommand cmd = new MySqlCommand();

               /*
               Para que o CSharp entenda que os comandos escritos no cmd precisam ser executados no banco de dados dbcliente,
               que foi representado com objeto de conexão, é necessário estabelecer relação entre cmd e conexão. Faremos isso 
               com o comando cmd.connection=conexao 
                */                                 

                cmd.Connection = conexao;

                /*
                Vamos dizer qual será o tipo de comando que será executado no banco de dados:
                    -StoreProcedure -> Stored(Armazenado) Procedure(Procedimento|Função)
                    -Text -> Você escreve o comando sql ponto a ponto para ser executado
                    -TableDirect -> Manipular a tabela diretamente
                 */                                               
                 cmd.CommandType = System.Data.CommandType.Text;

                 /*
                 Ápos ter selecionado o tipo de comando a ser executado, você precisa escrever o comando,
                 efetivamente, que será executado. Neste caso utilizaremos o comando Insert
                  */
                     cmd.CommandText ="insert into cliente(nome,email,telefone,idade) values('"+nome+"','"+email+"','"+telefone+"',"+idade+")";          

                     /*
                     Vamo executar a consulta com o comando ExecuteNonQuery(). Execute ->Executa a consulta
                     None(None->Nenhum) Query(Consulta), ou seja, o comando será executado, porém não retorna
                     o que foi inserido apenas se foi inserido(1) ou não(0)
                      */                                                   

                      int rs = cmd.ExecuteNonQuery();

                      if(rs > 0)
                      msg = "Cliente cadastrado com sucesso!";
                      else
                      msg = "Não foi possível cadastrar o cliente!";

                      //Fechar conexão com o banco de dados
                      conexao.Close();

                      return msg;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

        }

            public List<Cliente> list(){

                List<Cliente> lst = new List<Cliente>();

                MySqlConnection conexao = new MySqlConnection("Server=localhost;Port=3306;Database=dbcliente;User Id=root;Password=");
                conexao.Open();//Vamos abrir o banco de dados
                
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conexao;

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = "Select id, nome, email, telefone, idade, datacadastro from cliente";

                cmd.ExecuteReader();

                /*
                Para executar e ler os dados a partir do comando select, iremos usar uma execução com o comando ExecuteReader
                (executa a consulta e lê o resultado). Esse resultado será armazenado em uma variável do tipo Reader(Leitor) 
                para suportar os dados que retornam da consulta
                 */
                
                 MySqlDataReader dr = cmd.ExecuteReader();

                 /*
                 Os dados retornados do comando select foram armazenados na variável dr.
                 Com estes dados iremos popular a lista de clientes criada acima.
                 Para realizar essa operação, usaremos a estrutura de repetição while, pois não sabemos
                 onde os dados terminam.
                 Enquanto for possível ler o conteúdo de dr continue a buscar os dados e popular a lista de clientes
                  */

                  while(dr.Read()){
                      Cliente cli = new Cliente();
                      cli.id = dr.GetInt32("id");
                      cli.nome = dr.GetString("nome");
                      cli.email = dr.GetString("email");
                      cli.telefone = dr.GetString("telefone");
                      cli.idade = dr.GetInt32("idade");
                      cli.datacadastro = dr.GetDateTime("datacadastro");
                      lst.Add(cli);

                  }
            }
    }
}