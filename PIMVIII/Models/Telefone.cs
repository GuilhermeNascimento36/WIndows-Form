using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Telefone
    {
        protected int Id;
        public int Numero;
        public int Ddd;
        TipoTelefone Tipo = new TipoTelefone();
    }
}
