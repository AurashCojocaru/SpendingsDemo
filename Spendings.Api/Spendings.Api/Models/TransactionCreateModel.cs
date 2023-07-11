using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spendings.Api.Models
{
    public class TransactionCreateModel
    {
        
        public decimal Value { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
