using GcoinNode.Dtos;
using GcoinNode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace GcoinNode.Data.impl
{
    public class BlockRepo : IBlockRepo
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
        public void AddBlock(List<Transaction> transactions)
        {

            /* Creae Block*/
            var lastBlock = GetLastBlock();
            var nextHeight = lastBlock.Height + 1;
            var prevHash = lastBlock.Hash;
            var timeStamp = DateTime.Now.Ticks;
            byte[] hash = GenerateHash(transactions, timeStamp, prevHash);

            var block = new Block();
            block.Height = nextHeight;
            block.PrevHash = prevHash;
            block.TimeStamp = timeStamp;
            block.Hash = hash;
            block.Transactions = transactions.ToArray();

            _context.BlockItem.Add(block);
            _context.SaveChanges();

        }
        public void CreateGenesisBlock()
        {
            // first block of the Blockchain

        }

        public byte[] GenerateHash(List<Transaction> transactions, long ts, byte[] ph)
        {
            var sha = SHA256.Create();
            byte[] timeStamp = BitConverter.GetBytes(ts);
            var transactionHash = (transactions.ToArray());

            byte[] headerBytes = new byte[timeStamp.Length 
                                    + ph.Length 
                                    + transactionHash.Length];
                
            byte[] hash = sha.ComputeHash(headerBytes);

            return hash;
        }

        // Save state
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }

        IEnumerable<BlockDto> IBlockRepo.GetBlockchain()
        {
            throw new NotImplementedException();
        }

        public BlockDto GetBlockById(int id)
        {
            throw new NotImplementedException();
        }

        BlockDto IBlockRepo.GetLastBlock()
        {
            throw new NotImplementedException();
        }

        BlockDto IBlockRepo.GetGenesisBlock()
        {
            throw new NotImplementedException();
        }

        public void AddBlock(List<TransactionReadDto> transaction)
        {
            throw new NotImplementedException();
        }
    }
}
