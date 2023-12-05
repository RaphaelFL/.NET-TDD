using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Operador
    {
        private string _nome;
        private string _matricula;
        
        public string Nome { get { return _nome; } set { _nome = value; } }
        public string Matricula { get { return _matricula; } set { _matricula = value; } }

        public Operador()
        {
            this.Matricula = new Guid().ToString().Substring(0, 8);
        }
        public override string ToString()
        {
            return $"Operador: {this.Nome}" +
                   $"Matricula: {this.Matricula}";
        }
    }
}
