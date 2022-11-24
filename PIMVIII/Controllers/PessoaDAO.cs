using System;
using Model;
using System.Data.SqlClient;//referenciando a classe Data que contém as instruções para conectar ao SqlServer
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;


namespace Controller
{
    public class PessoaDAO
    {
        //alocando string de conexao com o bd
        SqlConnection conexao = new SqlConnection(@"AQUI FICA A STRING DE CONEXÃO");

        public bool cadastrar(Pessoa p)
        {
            
            conexao.Open();

            //Declarando o insert de cada tabela em uma string
            string queryInsert = "INSERT INTO tb_pessoa (id, nome, cpf) VALUES (@id, @nome, @cpf); " +
                "INSERT INTO tb_endereco (id, logradouro, numero, cep, bairro, cidade, estado) VALUES (@id, @rua, @numero, @cep, @bairro, @cidade, @estado) " +
                "INSERT INTO tb_telefone (id, telefone, ddd) VALUES (@id, @telefone, @ddd); " +
                "INSERT INTO tb_tipotelefone (id, tipoTelefone) VALUES (@id, @tipoTel)";



            //Gerando ID automaticamente, seria o mesmo que colocar o campo automático no access
            Random randomId = new Random();

            // pulando para o próximo ID
            randomId.Next();


            try{
                //criando um objeto command para passar nossa instrução e nossa conexão
                SqlCommand comando = new SqlCommand(queryInsert, conexao);


                //inserindo os dados da view na variáveis que serão enviadas para o banco
                comando.Parameters.Add(new SqlParameter("@id", randomId.Next()));
                comando.Parameters.Add(new SqlParameter("@nome", p.Nome));
                comando.Parameters.Add(new SqlParameter("@cpf", p.Cpf));

                //apenas para endereço por ser uma tabela a parte
                comando.Parameters.Add(new SqlParameter("@rua", p.Endereco.Logradouro));
                comando.Parameters.Add(new SqlParameter("@numero", p.Endereco.Numero));
                comando.Parameters.Add(new SqlParameter("@cep", p.Endereco.Cep));
                comando.Parameters.Add(new SqlParameter("@bairro", p.Endereco.Bairro));
                comando.Parameters.Add(new SqlParameter("@cidade", p.Endereco.Cidade));
                comando.Parameters.Add(new SqlParameter("@estado", p.Endereco.Estado));


                //apenas para telefone
                comando.Parameters.Add(new SqlParameter("@telefone", p.Telefones.Numero));
                comando.Parameters.Add(new SqlParameter("@ddd", p.Telefones.Ddd));
                comando.Parameters.Add(new SqlParameter("@tipoTel", p.Telefones.Tipo.Tipo));

                if (comando.ExecuteNonQuery() > 0)
                {
                    conexao.Close();
                    return true;
                }
                
                else
                {
                    conexao.Close();
                    return false;
                }
            }

            catch (SqlException ex)
            {
                conexao.Close();
                throw new Exception("Erro ao cadastrar paciente. " + ex.Message);  
            }

            finally
            {
                conexao.Close();
            }
        }

        public bool excluir(Pessoa p)
        {
            conexao.Open();

            string queryDelete = "DELETE FROM tb_pessoa WHERE id = @id;" +
                "DELETE FROM tb_endereco WHERE tb_endereco.id=@id;" +
                "DELETE FROM tb_telefone WHERE tb_telefone.id=@id;" +
                "DELETE FROM tb_tipotelefone WHERE tb_tipotelefone.id=@id ";

            try
            {
                SqlCommand comando = new SqlCommand(queryDelete, conexao);
                comando.Parameters.Add(new SqlParameter("@id", p.PessoaId));

                if (comando.ExecuteNonQuery() > 0)
                {
                    conexao.Close();
                    return true;
                }

                else
                {
                    conexao.Close();
                    return false;
                }
            }

            catch (SqlException ex)
            {
                conexao.Close();
                throw new Exception("Erro ao excluir paciente. " + ex.Message);
            }

            finally
            {
                conexao.Close();
            }
        }
        
        public bool alterar(Pessoa p)
        {
            conexao.Open();

            string queryUpdate = "UPDATE tb_pessoa SET nome = @nome WHERE cpf = @cpf;" +
                "UPDATE tb_endereco SET logradouro=@logradouro, cep=@cep, numero=@numero, bairro=@bairro, cidade=@cidade, estado=@estado WHERE tb_endereco.id=@id;" +
                "UPDATE tb_telefone SET telefone=@telefone, ddd=@ddd  WHERE tb_telefone.id=@id;" +
                "UPDATE tb_tipotelefone SET tipotelefone=@tipo WHERE tb_tipotelefone.id=@id ";

            try
            {
                SqlCommand comando = new SqlCommand(queryUpdate, conexao);
                comando.Parameters.Add(new SqlParameter("@nome", p.Nome));
                comando.Parameters.Add(new SqlParameter("@cpf", p.Cpf));
                comando.Parameters.Add(new SqlParameter("@id", p.PessoaId));

                //endereço
                comando.Parameters.Add(new SqlParameter("@logradouro", p.Endereco.Logradouro));
                comando.Parameters.Add(new SqlParameter("@numero", p.Endereco.Numero));
                comando.Parameters.Add(new SqlParameter("@cep", p.Endereco.Cep));
                comando.Parameters.Add(new SqlParameter("@bairro", p.Endereco.Bairro));
                comando.Parameters.Add(new SqlParameter("@cidade", p.Endereco.Cidade));
                comando.Parameters.Add(new SqlParameter("@estado", p.Endereco.Estado));

                //telefone
                comando.Parameters.Add(new SqlParameter("@telefone", p.Telefones.Numero));
                comando.Parameters.Add(new SqlParameter("@ddd", p.Telefones.Ddd));
                comando.Parameters.Add(new SqlParameter("@tipo", p.Telefones.Tipo.Tipo));

                if (comando.ExecuteNonQuery() > 0)
                {
                    conexao.Close();
                    return true;
                }

                else
                {
                    conexao.Close();
                    return false;
                }
            }

            catch (SqlException ex)
            {
                conexao.Close();
                throw new Exception("Erro ao alterar dados do paciente. " + ex.Message);
            }

            finally
            {
                conexao.Close();
            }
        }

        public Pessoa consulte(long cpf)
        {
            Pessoa p = new Pessoa();
            Endereco end = new Endereco();
            Telefone tel = new Telefone();
            TipoTelefone tipoTel = new TipoTelefone();

            conexao.Open();

            string querySelect = "SELECT nome, cpf, tb_pessoa.id, cep, numero, estado, bairro, cidade, logradouro, telefone, ddd, tipoTelefone " +
                "from tb_pessoa " +
                "INNER JOIN  tb_endereco ON tb_pessoa.id = tb_endereco.id " +
                "INNER JOIN tb_telefone ON tb_pessoa.id = tb_telefone.id " +
                "inner join tb_tipotelefone on tb_pessoa.id = tb_tipotelefone.id " +
                "where tb_pessoa.cpf = @cpf";

            SqlCommand cmd = new SqlCommand(querySelect, conexao);
            try
            {
                cmd.Parameters.AddWithValue("@cpf", cpf);

                SqlDataReader dr = cmd.ExecuteReader();
                


                while (dr.Read())
                {
                    p.PessoaId = (int)dr["id"];
                    p.Nome = (string)dr["nome"];
                    p.Cpf = (long)dr["cpf"];

                    //endereço
                    end.Cep = (int)dr["cep"];
                    end.Estado = (string)dr["estado"];
                    end.Cidade = (string)dr["cidade"];
                    end.Bairro = (string)dr["bairro"];
                    end.Numero = (int)dr["numero"];
                    end.Logradouro = (string)dr["logradouro"];

                    //telefone
                    tel.Numero = (int)dr["telefone"];
                    tel.Ddd = (int)dr["ddd"];
                    tipoTel.Tipo = (string)dr["tipoTelefone"];
                }

                tel.Tipo = tipoTel;
                p.Endereco = end;
                p.Telefones = tel;
                conexao.Close();
                return p;
            }

            catch (SqlException ex)
            {
                conexao.Close();
                throw new Exception("Erro ao buscar paciente. " + ex.Message);
            }

            finally
            {
                conexao.Close();
            }
        }

    }
}
