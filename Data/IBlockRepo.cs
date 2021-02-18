using GcoinNode.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public void CreateBlock();
        public void CreateGenesisBlock();   
    }
}
