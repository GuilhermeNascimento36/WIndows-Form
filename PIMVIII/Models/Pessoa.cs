namespace Models
{
    public class Pessoa
    {
        protected int Id;
        public string Nome;
        public long Cpf;
        Endereco Endereco = new Endereco();
        Telefone Telefones = new Telefone();
    }
}