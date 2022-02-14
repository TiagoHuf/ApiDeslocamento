using ApiDeslocamento.Domain.Entities;
using ApiDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Application.Condutores.Queries
{
    public class GetDeslocamentoQuery : IRequest<Deslocamentos>
    {
        public long DeslocamentoId { get; set; }
    }

    public class GetDeslocamentosQueryHandler : IRequestHandler<GetDeslocamentoQuery, Deslocamentos>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Deslocamentos> Handle(GetDeslocamentoQuery request, CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamentos>();

            var deslocamento = await repositoryDeslocamento
                .FindBy(d => d.Id == request.DeslocamentoId)
                .Include(c => c.Carro).Include(c => c.Cliente)
                .Include(c => c.Condutor)
                .FirstAsync(cancellationToken);

            return deslocamento;
        }
    }
}
