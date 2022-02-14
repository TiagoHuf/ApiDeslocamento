using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Domain.Entities
{
    public class Cliente : BaseEntity
    {

        public Cliente(string cpf, string nome)
        {
            Cpf = cpf;
            Nome = nome;
        }

        private Cliente()
        {
        }
        public string Cpf { get; private set; }

        public string Nome { get; private set; }

        private readonly List<Deslocamentos> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamentos> Deslocamentos =>
            _deslocamentos.AsReadOnly();
    }
}