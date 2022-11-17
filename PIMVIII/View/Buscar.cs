using System;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class Buscar : Form
    {
        Pessoa p = new Pessoa();
        Endereco end = new Endereco();
        Telefone tel = new Telefone();
        TipoTelefone tipoTel = new TipoTelefone();

        PessoaDAO paciente = new PessoaDAO();

        public Buscar()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            long cpfBuscar = Convert.ToInt64(txtBuscarCpf.Text);
            Pessoa recebeDados = new Pessoa();
            recebeDados = paciente.consulte(cpfBuscar);
            
            if(recebeDados.PessoaId != 0)
            {
                txtId.Text = Convert.ToString(recebeDados.PessoaId);
                txtNome.Text = recebeDados.Nome;
                txtCpf.Text = Convert.ToString(recebeDados.Cpf);

                txtBairro.Text = Convert.ToString(recebeDados.Endereco.Bairro);
                txtCep.Text = Convert.ToString(recebeDados.Endereco.Cep);
                txtCidade.Text = Convert.ToString(recebeDados.Endereco.Cidade);
                txtNumero.Text = Convert.ToString(recebeDados.Endereco.Numero);
                txtLogradouro.Text = Convert.ToString(recebeDados.Endereco.Logradouro);
                txtEstado.Text = Convert.ToString(recebeDados.Endereco.Estado);

                txtTelefone.Text = Convert.ToString(recebeDados.Telefones.Numero);
                txtDdd.Text = Convert.ToString(recebeDados.Telefones.Ddd);
                txtTipo.Text = Convert.ToString(recebeDados.Telefones.Tipo.Tipo);
            }
            else
            {
                MessageBox.Show("Paciente não encontrado.", "Erro na busca.");
                limparTxtBox();
            }
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            p.Nome = txtNome.Text;
            p.PessoaId = Convert.ToInt32(txtId.Text);
            p.Cpf = Convert.ToInt64(txtCpf.Text);

            end.Cep = Convert.ToInt32(txtCep.Text);
            end.Logradouro = Convert.ToString(txtLogradouro.Text);
            end.Cidade = Convert.ToString(txtCidade.Text);
            end.Estado = Convert.ToString(txtEstado.Text);
            end.Numero = Convert.ToInt32(txtNumero.Text);
            end.Bairro = Convert.ToString(txtBairro.Text);

            
            tel.Numero = Convert.ToInt32(txtTelefone.Text);
            tel.Ddd = Convert.ToInt32(txtDdd.Text);
            tipoTel.Tipo = Convert.ToString(txtTipo.Text);
            tel.Tipo = tipoTel;

            //atribuindo em pessoa
            p.Endereco = end;
            p.Telefones = tel;

            bool resultado = paciente.alterar(p);

            if (resultado)
            {
                MessageBox.Show("Dados do paciente alterados com sucesso!", "Dados Alterados");
                limparTxtBox();
            }
            else 
            {
                MessageBox.Show("Não foi possível alterar os dados desse paciente.", "Erro!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            txtBuscarCpf.Text = String.Empty;
            txtId.Text = String.Empty;
            txtBuscarCpf.Focus();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult btnResultado = MessageBox.Show("Deseja realmente excluir o paciente?", "Deletar registro", btn, MessageBoxIcon.Warning);

            if (btnResultado == DialogResult.Yes)
            {
                p.PessoaId = Convert.ToInt32(txtId.Text);
                bool resultado = paciente.excluir(p);
                if (resultado)
                {
                    MessageBox.Show("Paciente excluído com sucesso.", "Sucesso!");
                    limparTxtBox();
                }
                else
                {
                    MessageBox.Show("Não foi possível excluir paciente.", "Erro!");
                }
            }
        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void Buscar_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscarCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
