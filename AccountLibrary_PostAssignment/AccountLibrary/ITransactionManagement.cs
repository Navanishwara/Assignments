using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary
{
    public interface ITransactionManagement
    {
        void Deposit(decimal amount,int id);
        void Withdraw(decimal amount,int id);
        void TransferFunds(int id1, int id2,decimal amount);
    }
}
