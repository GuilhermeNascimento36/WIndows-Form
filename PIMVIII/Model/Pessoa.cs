namespace Model
{
    public class Pessoa
    {
        protected int Id;
        public int PessoaId; //pessoaDAO não herda o id
        public string Nome;
        public long Cpf;
        public Endereco Endereco;
        public Telefone Telefones;
    }
}
