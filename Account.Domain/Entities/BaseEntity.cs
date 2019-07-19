using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Identificador único do registro no banco de dados.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Data de criação do registro.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Data de atiaçozação do registro
        /// </summary>
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
