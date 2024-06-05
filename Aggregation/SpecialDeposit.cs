namespace Aggregation
{
    public class SpecialDeposit : Deposit
    {
        public SpecialDeposit(decimal a, int b) : base(a, b)
        {

        }

        public override decimal Income()
        {
            int i = 1;
            decimal sum = 0, money = Amount;
            double percent = 0.01;
            while(i <= Period)
            {
                sum += (decimal)((double)money * percent);
                money += (decimal)((double)Amount * percent);
                percent += 0.01;
                i++;
            }
            return sum;
        }
    }

}