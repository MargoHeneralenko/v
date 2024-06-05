using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal amount, int period) : base(amount, period)
        {
            
        }
        public override decimal Income()
        {
            decimal summ = Amount;

            for (int i = 0; i < Period; i++)
            {
                summ += summ * 0.05m;
            }
            summ = Math.Round(summ, 2);
            
            decimal incomeAmount = summ - Amount;

            return incomeAmount;
        }
    }
}