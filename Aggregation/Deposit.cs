namespace Aggregation
{
    public abstract class Deposit
    {
        public decimal Amount { get; }
        public int Period { get; }
        
        protected Deposit(decimal depositAmount, int depositPeriod)
        {
            Period = depositPeriod;
            Amount = depositAmount;
        }

        public abstract decimal Income();
    }
}