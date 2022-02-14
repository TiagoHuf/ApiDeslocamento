using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Domain.Entities
{
    public class Carro : BaseEntity
    {

        public Carro(string placa, string descricao)
        {
            Placa = placa;
            Descricao = descricao;
        }

        private Carro()
        {
        }
        public string Placa { get; private set; }

        public string Descricao { get; private set; }

        private readonly List<Deslocamentos> _deslocamentos = new();
        public IReadOnlyCollection<Deslocamentos> Deslocamentos =>
            _deslocamentos.AsReadOnly();
    }
}