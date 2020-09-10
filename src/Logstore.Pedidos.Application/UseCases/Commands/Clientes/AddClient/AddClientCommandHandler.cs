using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Clientes;
using Logstore.Pedidos.Infrastructure.Shared.Constants;
using Logstore.Pedidos.Infrastructure.Shared.DomainObjects;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Application.UseCases.Commands.Clientes.AddClient
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, ResultCommand>
    {
        private readonly IClienteRepository _repository;
        public AddClientCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultCommand> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = Parse(request);
                if (!cliente.EstaConsistente())
                    return new ResultCommand(cliente.ListaErros, StatusCode.Invalid);
                var entity = await _repository.SaveAsync(cliente);
                
                request.AssociateId(entity.Id);
                return new ResultCommand(request, StatusCode.IsSuccess);
            }
            catch (Exception err)
            {
                return new ResultCommand(err.Message, StatusCode.Invalid);
            }
        }

        private Cliente Parse(AddClientCommand command)
        {
            return new Cliente(command.Nome,
                               command.Telefone,
                               command.CPF,
                               0
                               );
        }
    }
}