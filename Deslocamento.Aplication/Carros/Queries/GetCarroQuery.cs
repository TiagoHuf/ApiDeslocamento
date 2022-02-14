using ApiDeslocamento.Domain.Entities;
using ApiDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeslocamento.Application.Carros.Queries
{
    public class GetCarroQuery : IRequest<Carro>
    {
        public long CarroId { get; set; }
    }

    public class GetCarrosQueryHandler : IRequestHandler<GetCarroQuery, Carro>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarrosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Carro> Handle(GetCarroQuery request, CancellationToken cancellationToken)
        {
            var repositoryCarro = _unitOfWork.GetRepository<Carro>();

            var carro = await repositoryCarro
                .FindBy(d => d.Id == request.CarroId)
                .Include(d => d.Deslocamentos)
                .FirstAsync(cancellationToken);

            return carro;
        }
    }
}
