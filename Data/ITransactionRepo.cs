using System.Collections.Generic;
using GcoinNode.Models;

namespace GcoinNode.Data
{
    public interface ITransactionRepo
    {
        bool SaveChanges();

        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
        void CreateTransaction(Transaction transaction);
    }
}
