using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class LongDeposit : Deposit, IProlongable
    {
        public LongDeposit(decimal amount, int period) : base(amount, period)
        {
        }

        public bool CanToProlong()
        {
            if (Period < 3)
            {
                return true;
            }

            return false;
        }

        public override decimal Income()
        {
            int a;
            decimal summ = Amount;

            for (int i = 0; i < Period; i++)
            {
                if (i >= 6)
                {
                    summ += summ * 0.15m;
                }
               
            }
            
            decimal incomeAmount = summ - Amount;

            return incomeAmount;
        }
    }
}
