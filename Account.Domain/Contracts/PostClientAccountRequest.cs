using System;
using System.ComponentModel.DataAnnotations;

namespace Account.Domain.Contracts
{
    public class PostClientAccountRequest
    {
        /// <summary>
        /// Nome do correntista
        /// </summary>
        
        public string Name { get; set; }

        /// <summary>
        /// Documento de identificação
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Numero da Agencia
        /// </summary>
        public string AgencyNumber { get; set; }

        /// <summary>
        /// Numero da Conta
        /// </summary>
        public string AccountNumber { get; set; }
    }
}
