using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GcoinNode.Models
{
    [NotMapped]
    public class Block
    {
        public int Height { get; set; }
        public long TimeStamp { get; set; }
        public byte[] PrevHash { get; set; }
        public byte[] Hash { get; set; }
        public Transaction[] Transactions { get; set; }
        public string Creator { get; set; }
    }
}
