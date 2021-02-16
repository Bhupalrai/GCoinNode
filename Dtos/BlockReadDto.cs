using GcoinNode.Models;

namespace GcoinNode.Dtos
{
    public class BlockReadDto
    {
        public int Height { get; set; }
        public long TimeStamp { get; set; }
        public byte[] PrevHash { get; set; }
        public byte[] Hash { get; set; }
        public Transaction[] Transactions { get; set; }
        public string Creator { get; set; }
    }
}
