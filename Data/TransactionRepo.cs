using System;
using System.Collections.Generic;
using System.Linq;
using GcoinNode.Models;


namespace GcoinNode.Data.impl
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepo(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void CreateTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            _context.TransactionItem.Add(transaction);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.TransactionItem.ToList();
        }

        public Transaction GetTransactionById(int id)
        {
            return _context.TransactionItem.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

