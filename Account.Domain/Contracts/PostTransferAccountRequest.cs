using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Contracts
{
    public class PostTransferAccountRequest
    {
        /// <summary>
        /// Identificação do responsavel que esta enviando
        /// </summary>
        public Guid AccountIDfrom { get; set; }

        /// <summary>
        /// Identificação do responsavel que esta recebendo
        /// </summary>
        public Guid AccountIDto { get; set; }

        /// <summary>
        /// valor da transferencia
        /// </summary>
        public decimal value { get; set; }
    }
}
