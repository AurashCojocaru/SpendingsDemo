using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spendings.DataAccess
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }
        
        [Column(TypeName = "nvarchar(1028)")]
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
