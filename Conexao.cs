using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace ConexaoBD{
    class Conexao{
        string dadosConexao = "server=localhost;user=root;database=teste_ti42;port=3306;password=";

        public int ExecutaComando(string query)
        {
            //Criar e abre con~exão
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            //rodar a query 
            MySqlCommand comando = new MySqlCommand(query, conexao);
            int linhasAfetadas = comando.ExecuteNonQuery();
            conexao.Close();
            return linhasAfetadas;
        }

        public DataTable ExecutaSelect(string query)
        {
            //Criar e abre con~exão
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            //rodar a query 
            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataAdapter dados = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            dados.Fill(dt);
            conexao.Close();
            return dt;
        }

        //public List<Produto> BuscaProdutos(){
        //    MySqlConnection conexao = new MySqlConnection(dadosConexao);
        //    conexao.Open();
        //    Console.WriteLine("Conexão realizada com sucesso!");

        //    string sql = "SELECT * FROM produtos;";
        //    MySqlCommand comando = new MySqlCommand(sql, conexao);
        //    MySqlDataReader dados = comando.ExecuteReader();

        //    List<Produto> lista = new List<Produto>();
        //    while(dados.Read()){
        //        // Console.WriteLine("ID: " + dados[0]+" | Nome: " + dados[1] +" | Preço: " + dados[2] +" | Registro: " + dados[3] );
        //        Produto p = new Produto();
        //        p.id = dados.GetInt32("id");
        //        p.nome = dados.GetString("nome");
        //        p.preco = dados.GetFloat("preco");
        //        p.registro = dados.GetDateTime("resgistro");
        //        lista.Add(p);
        //    }

        //    conexao.Close();
        //    return lista;
        //}
    }
}