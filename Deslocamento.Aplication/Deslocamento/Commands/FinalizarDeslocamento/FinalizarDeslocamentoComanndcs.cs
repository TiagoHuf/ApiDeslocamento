using ApiDeslocamento.Domain.Entities;
using ApiDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslocamentoApp.Application.DeslocamentosCommands
{
    public class FinalizarDeslocamentoCommand : IRequest
    {
        public long DeslocamentoId { get; set; }
        public decimal QuilometragemFinal { get; set; }
    }
    public class FinalizarDeslocamentoCommandHandler : IRequestHandler<FinalizarDeslocamentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FinalizarDeslocamentoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            FinalizarDeslocamentoCommand request,
            CancellationToken cancellationToken)
        {
            var repositoryDeslocamento = _unitOfWork.GetRepository<Deslocamentos>();
            var deslocamento = await repositoryDeslocamento
               .FindBy(d => d.Id == request.DeslocamentoId)
               .FirstAsync(cancellationToken);

            deslocamento.FinalizarDeslocamento(request.QuilometragemFinal);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
