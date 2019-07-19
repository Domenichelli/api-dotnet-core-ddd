using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Domain.Contracts;
using Account.Domain.Response;
using Account.Interface.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : Controller
    {
        private readonly IAccountServiceRepository accountServiceRepository;
        private readonly ITransferServiceRepository transferServiceRepository;

        public TransferController(IAccountServiceRepository _accountServiceRepository, ITransferServiceRepository _transferServiceRepository)
        {
            accountServiceRepository = _accountServiceRepository;
            transferServiceRepository = _transferServiceRepository;
        }

        /// <summary>
        /// Devolve o extrato do cliente
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        [HttpGet("{account_id}")]
        [ProducesResponseType(typeof(ResultGeneric<string>), 200)]
        [ProducesResponseType(typeof(ResultGeneric<string>), 400)]
        public IActionResult Get(Guid account_id)
        {
            var result = transferServiceRepository.GetExtract(account_id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);   
        }


        /// <summary>
        /// Transfere valor entre contas
        /// </summary>
        /// <param name="request">Dados da conta</param>
        [ProducesResponseType(typeof(ResultGeneric<PostClientAccountResponse>), 201)]
        [ProducesResponseType(typeof(ResultGeneric<List<string>>), 400)]
        [HttpPost]
        public IActionResult PostTransferAccounts([FromBody] PostTransferAccountRequest request)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);
            else
            {
                var result = transferServiceRepository.Transfer(request);
                if (result.Success)
                    return Created("", result);
                else
                    return BadRequest(result);
            }
        }

        /// <summary>
        /// Deposita valor em uma conta
        /// </summary>
        /// <param name="account_id"></param>
        /// <param name="request">Dados da conta</param>
        [ProducesResponseType(typeof(ResultGeneric<string>), 201)]
        [ProducesResponseType(typeof(ResultGeneric<List<string>>), 400)]
        [HttpPost("{account_id}/deposit")]
        public IActionResult PostDeposit([FromRoute]Guid account_id, [FromBody] PostDepositAccountRequest request)
        {
            var result = transferServiceRepository.DepositAccount(account_id, request.value);
            if (result.Success)
                return Created("", result);
            else
                return BadRequest(result);
        }
    }
}