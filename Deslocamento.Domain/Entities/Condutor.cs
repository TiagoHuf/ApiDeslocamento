using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Domain.Entities
{
    public class Condutor : BaseEntity
    {

        public Condutor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        private Condutor()
        {
        }
        public string Nome { get; private set; }

        public string Email { get; private set; }

        private readonly List<Deslocamentos> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamentos> Deslocamentos =>
            _deslocamentos.AsReadOnly();
    }
}