using System;
using System.Windows.Forms;
using Model;
using Controller;

namespace View
{
    public partial class Cadastro : Form
    {
        Pessoa p = new Pessoa();
        Endereco end = new Endereco();
        Telefone tel = new Telefone();
        PessoaDAO paciente = new PessoaDAO();

        public Cadastro()
        {
            InitializeComponent();
        }

        public void limparTxtBox()
        {
            txtNome.Text = String.Empty;
            txtCpf.Text = String.Empty;
            txtTipo.Text = String.Empty;
            txtDdd.Text = String.Empty;
            txtTelefone.Text = String.Empty;
            txtCep.Text = String.Empty;
            txtLogradouro.Text = String.Empty;
            txtNumero.Text = String.Empty;
            txtCidade.Text = String.Empty;
            txtEstado.Text = String.Empty;
            txtBairro.Text = String.Empty;
            txtNome.Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //alocando em pessoa
            p.Nome = Convert.ToString(txtNome.Text);
            p.Cpf = Convert.ToInt64(txtCpf.Text);

            //alocando em endereço
            end.Cep = Convert.ToInt32(txtCep.Text);
            end.Logradouro = Convert.ToString(txtLogradouro.Text);
            end.Cidade = Convert.ToString(txtCidade.Text);
            end.Estado = Convert.ToString(txtEstado.Text);
            end.Numero = Convert.ToInt32(txtNumero.Text);
            end.Bairro = Convert.ToString(txtBairro.Text);

            //atribuindo em pessoa
            p.Endereco = end;

            //verificando quantidade de telefones
            int qtdTel = Convert.ToInt16(cboxQtdTelefone.Text);

            //instanciando o tipo telefone
            TipoTelefone telTipo = new TipoTelefone();
            telTipo.Tipo = Convert.ToString(txtTipo.Text);

            for (int i = 0; i < qtdTel; i++)
            {
                //alocando telefone
                tel.Numero = Convert.ToInt32(txtTelefone.Text);
                tel.Ddd = Convert.ToInt32(txtDdd.Text);
                tel.Tipo = telTipo;
                p.Telefones = tel;
            }

            bool retorno = paciente.cadastrar(p);

            if (retorno)
            {
                limparTxtBox();
                MessageBox.Show("Paciente cadastrado com sucesso!", "Cadastrado.") ;
            }
            else
            {
                MessageBox.Show("Não foi possível cadastrar o paciente", "Falha de cadastro");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }
    }
}
