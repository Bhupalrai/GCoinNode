
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GcoinNode.Dtos
{
    public class TransactionReadDto
    {
        public int Id { get; set; }

        [Required]
        [Timestamp]
        public long TimeStamp { get; set; }
        public string Sender { set; get; }
        // public string Recipient { set; get; }
        public double Amount { set; get; }
        public double Fee { set; get; }
    }

    public class TransactionCreateDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "timestamp is required")]
        public long TimeStamp { get; set; }

        [Required]
        public string Sender { set; get; }
        [Required]
        public string Recipient { set; get; }
        [Required]
        public double Amount { set; get; }
        [Required]
        public double Fee { set; get; }
    }
}
