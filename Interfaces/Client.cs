using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Diagnostics.Metrics;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        
        private readonly  Deposit [] deposits;
        
        public Client()
        {
            deposits = new Deposit[10];
        }
        
        public bool AddDeposit(Deposit deposit)
        {
            for(int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }
            return false;
        }

        public decimal TotalIncome()
        {
            decimal totalIncome = 0;

            foreach (Deposit deposit in deposits)
            {
                if (deposit != null)
                {
                    totalIncome += deposit.Income();
                }
            }

            return totalIncome;
        }
        
        public decimal MaxIncome()
        {
            decimal maxIncome = 0;

            foreach (Deposit deposit in deposits)
            {
                if (deposit != null)
                {
                    decimal currentIncome = deposit.Income();
                    maxIncome = Math.Max(maxIncome, currentIncome);
                }
            }

            return maxIncome;
        }

        public decimal GetIncomeByNumber(int number)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (number == i + 1 && deposits[i] != null)
                {
                    return deposits[i].Income();
                }
            }
            return 0;
        }

        public void SortDeposits()
        {
            if (deposits != null)
            {
                Array.Sort(deposits, (x, y) => Comparer<Deposit>.Default.Compare(y, x));
            }

        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            foreach (var deposit in deposits)
            {
                if (deposit != null)
                {
                    yield return deposit;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public int CountPossibleToProlongDeposit()
        {
            int count = 0;

            foreach (Deposit deposit in deposits)
            {
                if (deposit is IProlongable && ((IProlongable)deposit).CanToProlong())
                {
                    count++;
                }
            }

            return count;
        }
        
    }
}
