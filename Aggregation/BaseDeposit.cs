namespace Aggregation
{
    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal a, int b) : base(a, b)
        {
            
        }
        
        public override decimal Income()
        {
            int i = 1;
            decimal sum = 0;
            decimal money = Amount;
            while (i <= Period)
            {
                sum += money * 0.05m;
                money += money * 0.05m;
                i++;
            }
            return sum;
        }
    }

}