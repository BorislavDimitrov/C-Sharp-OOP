using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;
        public Chainblock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }
        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!this.Contains(tx))
            {
                transactions.Add(tx.Id, tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            transactions[id].Status = newStatus;
            ;
        }

        public bool Contains(ITransaction tx) => transactions.ContainsKey(tx.Id);

        public bool Contains(int id) => transactions.ContainsKey(id);
       
        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            IEnumerable<ITransaction> result = transactions.Where(x => x.Value.Amount >= lo && x.Value.Amount <= hi)
                .Select(x => x.Value);
            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> result = transactions.OrderByDescending(x => x.Value.Amount)
                .ThenBy(x => x.Value.Id).Select(x => x.Value);
            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> result = transactions.Where(x => x.Value.Status == status)
                .Select(x => x.Value.To);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> result = transactions.Where(x => x.Value.Status == status)
                .Select(x => x.Value.From);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public ITransaction GetById(int id)
        {
            ITransaction result = transactions.Where(x => x.Value.Id == id)
                .Select(x => x.Value).FirstOrDefault();

            if (result == null)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> result = transactions
                .Where(x => x.Value.To == receiver
                && x.Value.Amount >= lo && x.Value.Amount < hi)
                .OrderByDescending(x => x.Value.Amount)
                .ThenBy(x => x.Value.Id)
                .Select(x => x.Value);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> result = transactions.Where(x => x.Value.To == receiver)
                .OrderByDescending(x => x.Value.Amount)
                .ThenBy(x => x.Value.Id)
                .Select(x => x.Value);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> result = transactions
                .Where(x => x.Value.From == sender && x.Value.Amount > amount)
                .OrderByDescending(x => x.Value.Amount)
                .Select(x => x.Value);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }
            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> result = transactions
               .Where(x => x.Value.From == sender)
               .OrderByDescending(x => x.Value.Amount)
               .Select(x => x.Value);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> result = transactions
               .Where(x => x.Value.Status == status)
               .OrderByDescending(x => x.Value.Amount)
               .Select(x => x.Value);

            if (result.Count() == 0)
            {
                throw new InvalidOperationException();
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            IEnumerable<ITransaction> result = transactions
               .Where(x => x.Value.Status == status && x.Value.Amount <= amount)
               .OrderByDescending(x => x.Value.Amount)
               .Select(x => x.Value);

            return result;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in transactions)
            {
                yield return transaction.Value;
            }
        }

        public void RemoveTransactionById(int id)
        {
            if (!transactions.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
