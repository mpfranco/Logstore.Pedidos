using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Pedidos;
using Logstore.Pedidos.Domain.Entities.AgregacaoPedido;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Produtos;
using Logstore.Pedidos.Domain.Entities;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Enderecos;
using Logstore.Pedidos.Domain.Interfaces.IRepository.Clientes;

namespace Logstore.Pedidos.Application.Tests.Pedidos
{
    public class PedidoTests : IClassFixture<DbFixture>
    {
        private readonly IPedidoRepository _repository;
        private readonly IProdutoRepository _repositoryProduto;
        private readonly IEnderecoRepository _repositoryEndereco;
        private readonly IClienteRepository _repositoryCliente;
        public PedidoTests(DbFixture fixture)
        {
            var serviceProvider = fixture.ServiceProvider;
            _repository = serviceProvider.GetService<IPedidoRepository>();
            _repositoryProduto = serviceProvider.GetService<IProdutoRepository>();
            _repositoryEndereco = serviceProvider.GetService<IEnderecoRepository>();
            _repositoryCliente = serviceProvider.GetService<IClienteRepository>();
        }

        [Fact(DisplayName = "Adicionar Pedido")]
        [Trait("Categoria", "Pedido")]
        public async Task AdicionarPedido_ClienteCadastrado_DeveAdicionarComSucesso()
        {

            //Arrange 
            var listPedidoItens = new List<PedidoItem>();
            var clienteId = 1;
            var prod4Valor = await _repositoryProduto.FindById(4);
            var pedidoItem = new PedidoItem(0, 1, false, 0, prod4Valor.Valor);
            listPedidoItens.Add(pedidoItem);
            var pedido = new Domain.Entities.AgregacaoPedido.Pedido(clienteId, 0, listPedidoItens);



            //Act
            var result = await _repository.SaveAsync(pedido);


            //Assert
            Assert.True(result.Id > 0);
        }


        [Fact(DisplayName = "Adicionar Pedido Cliente Sem Cadastro")]
        [Trait("Categoria", "Pedido")]
        public async Task AdicionarPedido_ClienteSemCadastrado_DeveAdicionarComSucesso()
        {

            //Arrange 
            var listPedidoItens = new List<PedidoItem>();
            var endereco = new Endereco("Rua diadema", "71", "Casa 2", "Polvilho", "Cajamar", "SP");
            var enderecoResult = await _repositoryEndereco.SaveAsync(endereco);
            var cliente = new Cliente("Itaci Virginia", "11-99726-6004", "31035867766", enderecoResult.Id);
            var clienteResult = await _repositoryCliente.SaveAsync(cliente);
            var prod4Valor = await _repositoryProduto.FindById(4);
            var pedidoItem = new PedidoItem(0, 1, false, 0, prod4Valor.Valor);
            listPedidoItens.Add(pedidoItem);
            var pedido = new Domain.Entities.AgregacaoPedido.Pedido(clienteResult.Id, 0, listPedidoItens);


            //Act
            var result = await _repository.SaveAsync(pedido);


            //Assert
            Assert.True(result.Id > 0);
        }

        [Fact(DisplayName = "Validar Maxímo de Itens")]
        [Trait("Categoria", "Pedido")]
        public async Task ValidarQuantidadeMaximaItens_MaximoItens_DeveRetornarTotalNaoPermitido()
        {
            //Arrange
            var listPedidoItens = new List<PedidoItem>();
            var clienteId = 1;

            for (int i = 1; i <= 6; i++)
            {
                var prod = await _repositoryProduto.FindById(i);
                var pedidoItem = new PedidoItem(0, 1, false, 0, prod.Valor);
                listPedidoItens.Add(pedidoItem);
            }

            for (int i = 1; i <= 5; i++)
            {
                var prod = await _repositoryProduto.FindById(i);
                var pedidoItem = new PedidoItem(0, 1, false, 0, prod.Valor);
                listPedidoItens.Add(pedidoItem);
            }
            
            var pedido = new Domain.Entities.AgregacaoPedido.Pedido(clienteId, 0, listPedidoItens);


            //Act

            var result = pedido.EstaConsistente();

            //Assert
            Assert.True(!result);
        }

        [Fact(DisplayName = "Validar Mínimo de Itens")]
        [Trait("Categoria", "Pedido")]
        public async Task ValidarQuantidadeMInimoItens_MaximoItens_DeveRetornarTotalNaoPermitido()
        {

            //Arrange
            var listPedidoItens = new List<PedidoItem>();
            var clienteId = 1;
            var pedido = new Domain.Entities.AgregacaoPedido.Pedido(clienteId, 0, listPedidoItens);

            //Act
            var result = pedido.EstaConsistente();

            //Assert
            Assert.True(!result);
        }
    }
}
