using System;

namespace Account.Domain.Entities
{
    public class ClientEntity : BaseEntity
    {
        public ClientEntity()
        {
            ClientID = Guid.NewGuid();
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ClientID { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Documento do Cliente
        /// </summary>
        public string CPF { get; set; }
    }
}
