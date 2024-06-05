using System;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }

        public int Period { get; }

        protected Deposit(decimal depositAmount, int depositPeriod)
        {
            Amount = depositAmount;
            Period = depositPeriod;
        }

        public abstract decimal Income();

        public int CompareTo(Deposit other)
        {
            if (other == null) return 1;

            decimal thisTotalSum = Amount + Income();
            decimal otherTotalSum = other.Amount + other.Income();

            if (thisTotalSum > otherTotalSum)
            {
                return 1;
            }

            if (thisTotalSum < otherTotalSum)
            {
                return -1;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Deposit other = (Deposit)obj;
            return Amount == other.Amount && Period == other.Period && Income() == other.Income();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Period, Income());
        }

        public static bool operator ==(Deposit left, Deposit right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        public static bool operator !=(Deposit left, Deposit right)
        {
            return !(left == right);
        }

        public static bool operator <(Deposit left, Deposit right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Deposit left, Deposit right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Deposit left, Deposit right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Deposit left, Deposit right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
