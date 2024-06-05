namespace Aggregation
{
    public class LongDeposit : Deposit
    {
        public LongDeposit(decimal a, int b) : base(a,b)
        {

        }

        public override decimal Income()
        {
            int i = 1;
            decimal sum = 0;
            decimal money = Amount;

            while(i <= Period)
            {
                if (i > 6)
                {
                    sum += money * 0.15m; 
                    money += Amount * 0.15m;
                    i++;
                }
                else
                {
                    i++;
                }     
            }
            return sum;
        }
    }

}