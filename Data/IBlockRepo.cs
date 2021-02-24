using GcoinNode.Dtos;
using GcoinNode.Models;
using System.Collections.Generic;

namespace GcoinNode.Data
{
    public interface IBlockRepo
    {

        bool SaveChanges();

        IEnumerable<BlockDto> GetBlockchain();
        BlockDto GetBlockById(int id);
        public BlockDto GetLastBlock();
        public BlockDto GetGenesisBlock();

        // Create
        public void CreateGenesisBlock();
        void AddBlock(List<TransactionReadDto> transaction);
    }
}
