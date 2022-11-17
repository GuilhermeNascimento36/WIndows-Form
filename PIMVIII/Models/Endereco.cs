using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Endereco
    {
        protected int Id;
        public string Logradouro;
        public int Numero;
        public int Cep;
        public string Bairro;
        public string Cidade;   
        public string Estado;
    }
}
