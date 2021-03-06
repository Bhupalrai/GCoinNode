﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GcoinNode.Models
{
    public class Transaction
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
