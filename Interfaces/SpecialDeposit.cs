using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal amount, int period) : base(amount, period)
        {
            
        }

        public bool CanToProlong()
        {
            if (Amount > 1000)
            {
                return true;
            }

            return false;
        }

        public override decimal Income()
        {
            decimal summ = Amount;
            decimal percent = 1;

            for (int i = 0; i < Period; i++)
            {
                summ += summ * (percent/100);
                percent++;
            }
            
            decimal incomeAmount = summ - Amount;

            return incomeAmount;
        }
    }
}