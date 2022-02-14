using MediatR;
using ApiDeslocamento.Domain.Entities;
using ApiDeslocamento.Domain.Interfaces;

namespace ApiDeslocamento.Application.Clientes.Commands.AdicionarCliente
{
    public class AdicionarClienteCommand : IRequest<Cliente>
    {
        public string Cpf { get; set; }

        public string Nome { get; set; }

    }

    public class CriarClienteCommandHandler : IRequestHandler<AdicionarClienteCommand, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CriarClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(AdicionarClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteInserir = new Cliente(request.Cpf, request.Nome);

            var repositoryCliente = _unitOfWork.GetRepository<Cliente>();

            repositoryCliente.Add(clienteInserir);

            await _unitOfWork.CommitAsync();

            return clienteInserir;
        }
    }
}