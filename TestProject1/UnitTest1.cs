using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure.Services.Controllers;
using Xunit;



namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        private Mock<IMediator> _mediator;

        public UnitTest1()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public void GetContaCorrente_Success_Result()
        {

            _mediator.Setup(x => x.Send(It.IsAny<ContaCorrenteQueryRequest>(), new CancellationToken()))
                .ReturnsAsync(new ContaCorrenteQueryResponse { Nome = "Teste", Valor = 20, DataHora = DateTime.Now, Numero = 123 });

            var post = new ContaCorrenteController(_mediator.Object);

            var result = post.GetSaldoContaCorrente("");

            Assert.IsType<OkObjectResult>(result);

        }
    }
}