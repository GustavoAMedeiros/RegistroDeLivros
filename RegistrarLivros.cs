using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class RegistrarLivros
    {
        private int id;
        private string titulo;
        private string autor;
        private string genero;
        private string lancamento;

        public int ID 
        { 
          get { return id; } 
          set { id = value; } 
        }
        public string Titulo 
        { 
            get {  return titulo; } 
            set {  titulo = value; } 
        }
        public string Autor 
        { 
            get { return autor; } 
            set {  autor = value; } 
        }
        public string Genero 
        { 
            get {  return genero; } 
            set {  genero = value; } 
        }
        public string Lancamento 
        { 
            get { return lancamento; } 
            set { lancamento = value; } 
        }

        public bool RegistrarLivro()
        {
            try
            {
                MySqlConnection ConexaoSql = new MySqlConnection(ConexaoBanco.BancoDados);
                ConexaoSql.Open();

                string insert = $"insert into livros (Titulo,Autor,Genero,Lancamento) values ('{Titulo}', '{Autor}', '{Genero}', '{Lancamento}')";

                MySqlCommand comandoSql = ConexaoSql.CreateCommand();
                comandoSql.CommandText = insert;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro no cadastro - método RegistrarLivro: " + ex.Message);
                return false;
            }
        }

        public MySqlDataReader LocalizarLivro()
        {
            try
            {
                MySqlConnection ConexaoSql = new MySqlConnection(ConexaoBanco.BancoDados);
                ConexaoSql.Open();

                string select = $"select Titulo,Autor,Genero,Lancamento from livros where Titulo = '{Titulo}'";

                MySqlCommand comandoSql = ConexaoSql.CreateCommand();
                comandoSql.CommandText = select;

                MySqlDataReader reader = comandoSql.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método RegistarLivro: " + ex.Message);
                return null;
            }
        }

        public bool AtualizarLivro()
        {
            try
            {
                MySqlConnection ConexaoSql = new MySqlConnection(ConexaoBanco.BancoDados);
                ConexaoSql.Open();

                string update = $"update livros set Titulo = '{Titulo}', autor = '{Autor}', genero = '{Genero}', Lancamento = '{Lancamento}' where Titulo = '{Titulo}'";

                MySqlCommand comandoSql = ConexaoSql.CreateCommand();
                comandoSql.CommandText = update;

                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método AtualizarLivro: " + ex.Message);
                return false;
            }
        }

        public bool ExcluirLivro()
        {
            try
            {
                MySqlConnection conexaoSql = new MySqlConnection(ConexaoBanco.BancoDados);
                conexaoSql.Open();

                string delete = $"delete from livros where titulo = '{Titulo}'";

                MySqlCommand comandoSql = conexaoSql.CreateCommand();
                comandoSql.CommandText = delete;

                comandoSql.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - Método ExcluirLivro: " + ex.Message);
                return false;
            }
        }
    }
}
