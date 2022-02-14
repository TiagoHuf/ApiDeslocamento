using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Domain.Entities
{
    public class Deslocamentos : BaseEntity
    {

        public Deslocamentos(long carroId, long clienteId,
            long condutorId, decimal quilometragemInicial, string observacao)
        {
            CarroId = carroId;
            ClienteId = clienteId;
            CondurtorId = condutorId;
            DataHoraInicio = DateTime.Now;
            QuilometragemInicial = quilometragemInicial;
            Observacao = observacao;

        }

        private Deslocamentos()
        {
        }

        public long CarroId { get; private set; }

        public long ClienteId { get; private set; }

        public long CondurtorId { get; private set; }

        public DateTime DataHoraInicio { get; private set; }

        public DateTime? DataHorarioFim { get; private set; }

        public decimal QuilometragemInicial { get; private set; }

        public string Observacao { get; private set; }

        public decimal? QuilometragemFinal { get; private set; }

        public Carro Carro { get; private set; }

        public Cliente Cliente { get; private set; }
        
        public Condutor Condutor { get; private set; }

        public void FinalizarDeslocamento(decimal quilometragemfinal)
        {
            QuilometragemFinal = quilometragemfinal;
            DataHorarioFim = DateTime.Now;
        }
    }
}