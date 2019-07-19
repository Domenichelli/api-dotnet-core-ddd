using System;

namespace Account.Domain.Entities
{
    public class AccountEntity : BaseEntity
    {
        public AccountEntity()
        {
            AccountID = Guid.NewGuid();
        }

        /// <summary>
        /// Identificação comum da conta
        /// </summary>
        public Guid AccountID { get; set; }
        /// <summary>
        /// ID do dono da Conta
        /// </summary>
        public Guid ClientID { get; set; }

        /// <summary>
        /// Numero da Agencia
        /// </summary>
        public string AgencyNumber { get; set; }

        /// <summary>
        /// Numero da Conta
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Valor na conta
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Defini se a conta esta bloqueada
        /// </summary>
        public bool Bloqued { get; set; }
    }
}
