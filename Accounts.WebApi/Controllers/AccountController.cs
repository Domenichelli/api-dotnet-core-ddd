using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Application.Business;
using Account.Domain.Contracts;
using Account.Domain.Entities;
using Account.Domain.Response;
using Account.Interface.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountServiceRepository accountServiceRepository;

        public AccountController(IAccountServiceRepository _accountServiceRepository)
        {
            accountServiceRepository = _accountServiceRepository;
        }

        /// <summary>
        /// Devolve todas as contas existentes do cpf informado
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        [HttpGet("{identifier}")]
        [ProducesResponseType(typeof(ResultGeneric<string>), 200)]
        [ProducesResponseType(typeof(ResultGeneric<string>), 400)]
        public IActionResult Get(string identifier)
        {
            if(!Account.Application.Helpers.Helpers.IsCpf(identifier))
            {
                return BadRequest("CPF invalido");
            }
            else
            {
                var result = accountServiceRepository.GetAccountsByDocument(identifier);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);

            }
        }


        /// <summary>
        /// Cria uma nova conta corrente
        /// </summary>
        /// <param name="request">Dados da conta</param>
        [ProducesResponseType(typeof(ResultGeneric<PostClientAccountResponse>), 201)]
        [ProducesResponseType(typeof(ResultGeneric<List<string>>), 400)]
        [HttpPost]
        public IActionResult Post([FromBody] PostClientAccountRequest request)
        {
            if (!ModelState.IsValid)
                return Json(ModelState);

            var result = accountServiceRepository.Register(request);

            return Created("", result);
        }

        /// <summary>
        /// Bloquear ou desbloquear conta
        /// </summary>
        /// <param name="request">Dados da conta</param>
        [ProducesResponseType(typeof(ResultGeneric<string>), 200)]
        [ProducesResponseType(typeof(ResultGeneric<string>), 400)]
        [HttpPut]
        public IActionResult Put([FromBody] PutBloquedAccountRequest request)
        {
            var result = accountServiceRepository.LockAccount(request);
            if(result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
            
        }
    }
}