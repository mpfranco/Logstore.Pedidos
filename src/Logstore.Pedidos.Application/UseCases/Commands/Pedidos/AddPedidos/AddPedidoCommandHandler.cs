using Logstore.Pedidos.Application.UseCases.Commands.Pedidos.AddPedidos;
using Logstore.Pedidos.Application.UseCases.Queries.Clientes;
using Logstore.Pedidos.Application.UseCases.Queries.Produtos;
using Logstore.Pedidos.Application.ViewModels;
using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Entities.AgregacaoPedido;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Clientes;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Enderecos;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Pedidos;
using Logstore.Pedidos.Infrastructure.Shared.Constants;
using Logstore.Pedidos.Infrastructure.Shared.DomainObjects;
using Logstore.Pedidos.Infrastructure.Shared.Settings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Logstore.Pedidos.Application.UseCases.Commands.Pedidos.AddPedidos
{
    public class AddPedidoCommandHandler : IRequestHandler<AddPedidoCommand, ResultCommand>
    {
        private readonly IFindClientQuerie _querieClient;
        private readonly IPedidoRepository _repository;
        private readonly IEnderecoRepository _repositoryEndereco;
        private readonly IClienteRepository _repositoryCliente;
        private readonly IFindProdutoQuerie _querieProduto;
        private readonly LogStoreSettings _settings;
        public AddPedidoCommandHandler(IFindClientQuerie querieClient,
                                       IPedidoRepository repository,
                                       IFindProdutoQuerie querieProduto,
                                       IClienteRepository repositoryCliente,
                                       IEnderecoRepository repositoryEndereco,
                                       LogStoreSettings settings)
        {
            _querieClient = querieClient;
            _repository = repository;
            _querieProduto = querieProduto;
            _repositoryCliente = repositoryCliente;
            _repositoryEndereco = repositoryEndereco;
            _settings = settings;
        }
        public async Task<ResultCommand> Handle(AddPedidoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.PedidoItens.Count > _settings.maxItens)
                    return new ResultCommand($"Total de itens informado ({request.PedidoItens.Count}) está acima do permitido ({_settings.maxItens}) ", StatusCode.Invalid);
                if (request.PedidoItens.Count < _settings.minItens)
                    return new ResultCommand($"Itens não localizados para efetuar o pedido", StatusCode.Invalid);                
                if (request.ClientId <= 0)                    
                    request.ClientId = await adicionarCliente(request.Cliente);
                if (!clientValid(request.ClientId))
                    return new ResultCommand($"ClienteId {request.ClientId} não localizado", StatusCode.Invalid);

                var pedido = Parse(request);
                if (!pedido.EstaConsistente())
                    return new ResultCommand(pedido.ListaErros, StatusCode.Invalid);
                var entity = await _repository.SaveAsync(pedido);
                request.AssociateId(entity.Id);                
                return new ResultCommand(request, StatusCode.IsSuccess);
            }
            catch (Exception err)
            {
                return new ResultCommand(err.Message, StatusCode.Invalid);
            }
        }
        private Pedido Parse(AddPedidoCommand command)
        {
            var itens = ParseItem(command).ToList();
            var valorPedido = itens.Sum(item => item.ValorItem);
            return new Pedido(command.ClientId,
                              valorPedido,
                              itens);
        }

        private IEnumerable<PedidoItem> ParseItem(AddPedidoCommand command)
        {
            var listItens = new List<PedidoItem>();
            foreach (var item in command.PedidoItens)
            {
                var itemValor = valorItem(item.ProdutoId, item.Produto2Id, item.MeioaMeio);
                var pedidoItem = new PedidoItem(0,item.ProdutoId,item.MeioaMeio,item.Produto2Id,itemValor);
                listItens.Add(pedidoItem);
            }
            return listItens;
            

        }

        private Cliente ParseCliente(ClienteViewModel cliente, long EnderecoId)
        {            
            return new Cliente(cliente.Nome, cliente.Telefone,cliente.CPF, EnderecoId);
        }
        private Endereco ParseEndenreco(EnderecoViewModel endereco)
        {
            return new Endereco(endereco.Logradouro, 
                                endereco.Numero,
                                endereco.Complemento,
                                endereco.Bairro,
                                endereco.Cidade,
                                endereco.Estado);
        }
        private  bool clientValid(long clienteId)
        {
            return _querieClient.FindAsyncById(clienteId).Result != null;
        }

        private decimal valorItem(long ProdutoId, long Produto2Id, bool MeioaMeio)
        {
            if (MeioaMeio)
            {
                var produto = _querieProduto.FindById(ProdutoId).Result;
                var produto2 = _querieProduto.FindById(Produto2Id).Result;
                return (produto.Valor / 2) + (produto2.Valor / 2);
                
            }
            else
            {
                var produto = _querieProduto.FindById(ProdutoId).Result;
                return produto.Valor;
            }            
        }

        private async Task<long> adicionarCliente(ClienteViewModel clienteViewModel)
        {
            var endereco = await _repositoryEndereco.SaveAsync(ParseEndenreco(clienteViewModel.Endereco));
            var cliente = await _repositoryCliente.SaveAsync(ParseCliente(clienteViewModel, endereco.Id));
            return cliente.Id;
        }

        
        
    }
}
