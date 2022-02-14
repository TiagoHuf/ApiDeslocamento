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
    public class GetCondutorQuery : IRequest<Condutor>
    {
        public long CondutorId { get; set; }
    }

    public class GetCondutoresQueryHandler : IRequestHandler<GetCondutorQuery, Condutor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCondutoresQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Condutor> Handle(GetCondutorQuery request, CancellationToken cancellationToken)
        {
            var repositoryCondutor = _unitOfWork.GetRepository<Condutor>();

            var condutor = await repositoryCondutor
                .FindBy(d => d.Id == request.CondutorId)
                .Include(d => d.Deslocamentos)
                .FirstAsync(cancellationToken);

            return condutor;
        }
    }
}
