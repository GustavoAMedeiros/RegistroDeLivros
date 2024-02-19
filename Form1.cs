using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTitulo.Text.Equals("") && !txtAutor.Text.Equals("") && !txtGenero.Text.Equals("") && !txtLancamento.Text.Equals(""))
                {
                    RegistrarLivros ResLivro = new RegistrarLivros();

                    ResLivro.Titulo = txtTitulo.Text;
                    ResLivro.Autor = txtAutor.Text;
                    ResLivro.Genero = txtGenero.Text;
                    ResLivro.Lancamento = txtLancamento.Text;


                    if (ResLivro.RegistrarLivro())
                    {
                        MessageBox.Show("Livro registrado com sucesso");

                        txtTitulo.Clear();
                        txtAutor.Clear();
                        txtGenero.Clear();
                        txtLancamento.Clear();
                        txtTitulo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível cadastrar livro");
                    }

                }
                else
                {
                    MessageBox.Show("Por favor preencha todos os campos corretamento");

                    txtTitulo.Clear();
                    txtAutor.Clear();
                    txtGenero.Clear();
                    txtLancamento.Clear();
                    txtTitulo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar o livro: " + ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTitulo.Text.Equals(""))
                {
                    RegistrarLivros ResLivros = new RegistrarLivros();
                    ResLivros.Titulo = txtTitulo.Text;

                    MySqlDataReader reader = ResLivros.LocalizarLivro();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            txtTitulo.Text = reader["Titulo"].ToString();
                            txtAutor.Text = reader["autor"].ToString();
                            txtGenero.Text = reader["genero"].ToString();
                            txtLancamento.Text = ((DateTime)reader["Lancamento"]).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            MessageBox.Show("Livro não localizado");

                            txtAutor.Clear();
                            txtTitulo.Clear();
                            txtGenero.Clear();
                            txtLancamento.Clear();
                            txtTitulo.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Livro não localizado");

                        txtAutor.Clear();
                        txtTitulo.Clear();
                        txtGenero.Clear();
                        txtLancamento.Clear();
                        txtTitulo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor preencher o campo título para realizar a pesquisa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao localizar o livro: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtAutor.Clear();
            txtTitulo.Clear();
            txtGenero.Clear();
            txtLancamento.Clear();
            txtTitulo.Focus();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTitulo.Text.Equals("") && !txtAutor.Text.Equals("") && !txtGenero.Text.Equals("") && !txtLancamento.Text.Equals(""))
                {

                    RegistrarLivros ResLivros = new RegistrarLivros();
                    ResLivros.Titulo = txtTitulo.Text;

                    ResLivros.Autor = txtAutor.Text;
                    ResLivros.Genero = txtGenero.Text;
                    ResLivros.Lancamento = txtLancamento.Text;

                    if (ResLivros.AtualizarLivro())
                    {
                        MessageBox.Show("Cadastro do livro " + ResLivros.Titulo + " atualizado com sucesso");

                        txtTitulo.Clear();
                        txtAutor.Clear();
                        txtGenero.Clear();
                        txtLancamento.Clear();
                        txtTitulo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível atualizar cadastro do livro");

                        txtTitulo.Clear();
                        txtAutor.Clear();
                        txtGenero.Clear();
                        txtLancamento.Clear();
                        txtTitulo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Favor digitar título do livro para a atualização");

                    txtTitulo.Clear();
                    txtAutor.Clear();
                    txtGenero.Clear();
                    txtLancamento.Clear();
                    txtTitulo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar livro: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTitulo.Text.Equals("") && !txtAutor.Text.Equals("") && !txtGenero.Text.Equals("") && !txtLancamento.Text.Equals(""))
                {
                    RegistrarLivros ResLivros = new RegistrarLivros();
                    ResLivros.Titulo = txtTitulo.Text;

                    if (ResLivros.ExcluirLivro())
                    {
                        MessageBox.Show("Livro: " + ResLivros.Titulo + " excluído com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível exluir livro");

                        txtTitulo.Clear();
                        txtAutor.Clear();
                        txtGenero.Clear();
                        txtLancamento.Clear();
                        txtTitulo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Favor pesquisar título do livro que deseja excluir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao exlcuir livro: " + ex.Message);
            }
        }
    }
}
