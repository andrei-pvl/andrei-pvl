using System;
using System.Collections.Generic;

namespace MoneySumm
{
    public class Money : IMoney
    {
        private double _sum;
        public double Sum
        {
            get => _sum;
            set => _sum = value < 0 ?
           throw new ArgumentOutOfRangeException("Sum must be >= 0") : value;
        }

        public string CodVal { get; set; }

        private double _cursusd;
        public double CursUsd
        {
            get => _cursusd;
            set => _cursusd = value <= 0 ?
           throw new ArgumentOutOfRangeException("CursUsd must be > 0") : value;
        }

        public Money()
        {
        }
        public Money(double sum, string codVal)
        {
            Sum = sum;
            CodVal = codVal;
        }

        public Money(double sum, string codVal, double cursUsd)
        {
            Sum = sum;
            CodVal = codVal;
            CursUsd = cursUsd;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Money money = obj as Money;

            return Sum.Equals(money.Sum) && CodVal.Equals(money.CodVal);
        }

        public Money Add(Money money1)
        {
            Money res = Calculate(money1);
            Money res2 = Calculate(this);

            Money result = new Money(res.Sum + res2.Sum,CodVal);
            return result;
        }
        public Money Calculate(Money money)
        {
            return new Money((money.Sum * money.CursUsd), CodVal = "USD");
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

