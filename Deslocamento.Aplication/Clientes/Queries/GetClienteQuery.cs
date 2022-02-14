using ApiDeslocamento.Domain.Entities;
using ApiDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Application.Clientes.Queries
{
    public class GetClienteQuery : IRequest<Cliente>
    {
        public long ClienteId { get; set; }
    }

    public class GetClientesQueryHandler : IRequestHandler<GetClienteQuery, Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Handle(GetClienteQuery request, CancellationToken cancellationToken)
        {
            var repositoryCliente = _unitOfWork.GetRepository<Cliente>();

            var cliente = await repositoryCliente
                .FindBy(d => d.Id == request.ClienteId)
                .Include(d => d.Deslocamentos)
                .FirstAsync(cancellationToken);

            return cliente;
        }
    }
}
