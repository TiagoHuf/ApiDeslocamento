using ApiDeslocamento.Domain.Entities;
using ApiDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApp.Application.Queries
{
    public class GetDeslocamentosQuery : IRequest<List<Deslocamentos>>
    {
    }

    public class GetDeslocamentosQueryHandler :
        IRequestHandler<GetDeslocamentosQuery, List<Deslocamentos>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeslocamentosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Deslocamentos>> Handle(
            GetDeslocamentosQuery request,
            CancellationToken cancellationToken)
        {
            var repositoryDeslocamento =
                _unitOfWork.GetRepository<Deslocamentos>();

            var deslocamentos = await repositoryDeslocamento
                .GetAll()
                .ToListAsync(cancellationToken);

            return deslocamentos;
        }
    }
}