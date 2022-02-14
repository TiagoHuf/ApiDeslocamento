using MediatR;
using ApiDeslocamento.Domain.Entities;
using ApiDeslocamento.Domain.Interfaces;

namespace ApiDeslocamento.Application.Condutores.Commands.AdicionarCondutor
{
    public class AdicionarCondutorCommand : IRequest<Condutor>
    {
        public string Nome { get; set; }

        public string Email { get; set; }

    }

    public class CriarCondutorCommandHandler : IRequestHandler<AdicionarCondutorCommand, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarCondutorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(AdicionarCondutorCommand request, CancellationToken cancellationToken)
        {
            var condutorInserir = new Condutor(request.Nome, request.Email);

            var repositoryCondutor = _unitOfWork.GetRepository<Condutor>();

            repositoryCondutor.Add(condutorInserir);

            await _unitOfWork.CommitAsync();

            return condutorInserir;
        }
    }
}