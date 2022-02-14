using MediatR;
using ApiDeslocamento.Domain.Entities;
using ApiDeslocamento.Domain.Interfaces;

namespace ApiDeslocamento.Application.Deslocamento.Commands.AdicionarDeslocamento
{
    public class AdicionarDeslocamentoCommand : IRequest<Deslocamentos>
    {
        public long CarroId { get; set; }

        public long ClienteId { get; set; }

        public long CondutorId { get; set; }

        public decimal QuilometragemInicial { get; set; }

        public string? Observacao { get; set; }

    }

    public class CriarDeslocamentoCommandHandler : IRequestHandler<AdicionarDeslocamentoCommand, Deslocamentos>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamentos> Handle(AdicionarDeslocamentoCommand request, CancellationToken cancellationToken)
        {
            var deslocamentoInserir = new Deslocamentos(request.CarroId, request.ClienteId, request.CondutorId, request.QuilometragemInicial, request.Observacao);

            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamentos>();

            repositoryDeslocamento.Add(deslocamentoInserir);

            await _unitOfWork.CommitAsync();

            return deslocamentoInserir;
        }
    }
}