using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySum
{
    public class Money : IMoney
    {
        private double _sum;
        public double Sum
        {
            get => _sum;
            set => _sum = value < 0 ? throw new ArgumentOutOfRangeException("Sum must be >= 0") : value;
        }

        public string CodVal { get; set; }

        private double _cursusd;
        public double CursUsd
        {
            get => _cursusd;
            set => _cursusd = value <= 0 ? throw new ArgumentOutOfRangeException("CursUsd must be > 0") : value;
        }


        public Money()
        {
        }
        
        public Money(double sum, string codVal, double cursUsd)
        {
            Sum = sum;
            CodVal = codVal;
            CursUsd = cursUsd;
        }

        
        public bool Equals(Money money)        
        {
            if (money == null) return false;
            return Sum == money.Sum && CodVal == money.CodVal;
        }

        public double SumOfSum(Money money1, Money money2)
        {
            double sum = money1.Sum + money2.Sum;
            return sum;
        }

        public double Calculate(Money money)
        {
            return money.Sum * money.CursUsd;
        }

        public override string ToString()
        {
            return $"{Sum} {CodVal}";
        }

        public override int GetHashCode()
        {
            int hashCode = 315068866;
            hashCode = hashCode * -1521134295 + Sum.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CodVal);
            hashCode = hashCode * -1521134295 + CursUsd.GetHashCode();
            return hashCode;
        }
    }
}
