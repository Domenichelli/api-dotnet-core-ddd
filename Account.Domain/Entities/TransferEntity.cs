using Account.Domain.Enums;
using System;

namespace Account.Domain.Entities
{
    public class TransferEntity : BaseEntity
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

        /// <summary>
        /// Tipo de transação
        /// </summary>
        public ETypeTransaction TypeTransaction { get; set; }

        /// <summary>
        /// Tipo do pagamento utilizado na transferencia
        /// </summary>
        public ETypePay TypePay { get; set; }
    }
}
