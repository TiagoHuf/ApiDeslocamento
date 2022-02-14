using MediatR;
using ApiDeslocamento.Domain.Entities;
using ApiDeslocamento.Domain.Interfaces;

namespace ApiDeslocamento.Application.Carros.Commands.AdicionarCarro
{
    public class AdicionarCarroCommand : IRequest<Carro>
    {
        public string Placa { get; set; }

        public string Descricao { get; set; }

    }

    public class CriarCarroCommandHandler : IRequestHandler<AdicionarCarroCommand, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarCarroCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(AdicionarCarroCommand request, CancellationToken cancellationToken)
        {
            var carroInserir = new Carro(request.Placa, request.Descricao);

            var repositoryCarro = _unitOfWork.GetRepository<Carro>();

            repositoryCarro.Add(carroInserir);

            await _unitOfWork.CommitAsync();

            return carroInserir;
        }
    }
}