using GcoinNode.Dtos;
using GcoinNode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GcoinNode.Data.impl
{
    public class BlockRepo
    {
        private readonly ApplicationDbContext _context;
        public BlockRepo(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        IEnumerable<Block> GetBlockchain()
        {
            return _context.BlockItem.ToList();
        }

        
        public Block GetLastBlock()
        {
            return _context.BlockItem.Last();
        }
        public Block GetGenesisBlock()
        {
            return _context.BlockItem.First();
        }
        // Create
        public void AddBlock()
        {

            var lastBlock = GetLastBlock();
            var nextHeight = lastBlock.Height + 1;
            var prevHash = lastBlock.Hash;

            /*var transactions = TransactionPool;
            var block = new Block(nextHeight, prevHash, transactions, "Admin");
            Blocks.Add(block);*/
        }
        public void CreateGenesisBlock()
        {
            // first block of the Blockchain

        }


        // Save state
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

    }
}
