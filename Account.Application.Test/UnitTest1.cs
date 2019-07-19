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
            request.AccountID = Guid.Parse("8e5e8e5a-bb0e-4148-ae9b-745abc8dc0e4");
            request.Block = true;

            var result = accountService.LockAccount(request);

            Assert.False(result.Success);
            Assert.Equal("Conta já está: Bloqueada", result.Errors[0]);
        }

        [Fact]
        public void Testar_Bloquear_Conta()
        {
            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var accountService = new AccountService(accountRepository.Object, clientRepository.Object);


            var request = new PutBloquedAccountRequest();
            request.AccountID = Guid.Parse("8e5e8e5a-bb0e-4148-ae9b-745abc8dc0e4");
            request.Block = true;

            var result = accountService.LockAccount(request);

            Assert.True(result.Success);
        }

        [Fact]
        public void Testar_Desbloquear_Conta()
        {
            var accountRepository = new Mock<IAccountRepository>();
            var clientRepository = new Mock<IClientRepository>();
            var accountService = new AccountService(accountRepository.Object, clientRepository.Object);


            var request = new PutBloquedAccountRequest();
            request.AccountID = Guid.Parse("8e5e8e5a-bb0e-4148-ae9b-745abc8dc0e4");
            request.Block = true;

            var result = accountService.LockAccount(request);

            Assert.True(result.Success);
        }
    }
}
