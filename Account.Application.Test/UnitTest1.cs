using Account.Application.Business;
using Account.Domain.Contracts;
using Account.Domain.Entities;
using Account.Domain.Response;
using Account.Interface;
using Account.Interface.Business;
using Account.Interface.Infra;
using Moq;
using System;
using Xunit;

namespace Account.Application.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Tentar_Bloquear_Conta_Bloqueada()
        {
            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var accountService = new AccountService(accountRepository.Object, clientRepository.Object);


            var request = new PutBloquedAccountRequest();

            accountService.LockAccount(request);

            

        }

        public void Quando_tentar_transferir_um_valor_sem_saldo_disponivel_devo_receber_uma_mensagem_de_erro()
        {
            // prepare
            //var contaOrigem = new AccountEntity { BalanceValue = 100 };
            //var contaDestino = new AccountEntity { BalanceValue = 0 };
            //var valorTransferencia = 101;

            //var repository = new Mock<IAccountRepository>();

            //repository.Setup(d => d.GetById(0)).Returns(contaOrigem);
            //repository.Setup(d => d.GetById(1)).Returns(contaDestino);

            //// act
            //var service = new Account.Application.Business.Account(repository.Object);
            //var resultado = service.Transfer(contaOrigem, contaDestino, valorTransferencia);

            //// assert
            //Assert.True(resultado.Data);
            //Assert.Equal("whis=kas", resultado.Errors[0]);
        }
    }
}
