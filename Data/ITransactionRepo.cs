using System.Collections.Generic;
using GcoinNode.Models;
using GcoinNode.Dtos;

namespace GcoinNode.Data
{
    public interface ITransactionRepo
    {
        bool SaveChanges();

        IEnumerable<TransactionReadDto> GetAllTransactions();
        TransactionReadDto GetTransactionById(int id);
        void CreateTransaction(Transaction transaction);
    }
}
