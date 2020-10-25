using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace PulpeVirtual.Services.DataContext.Data {
    public abstract class Entity {
        protected Entity () {

        }

        protected Entity (DateTime transactionDate) {
            TransactionDate = transactionDate;
        }

        [NotMappedAttribute]
        public DateTime TransactionDate { get; set; }
    }
}