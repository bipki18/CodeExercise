using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern.Stretegy_Pattern
{
    class Class1
    {

    }


   public interface ICalculate
    {
        int CalculateAmount(int a, int b);
    }


    public class Plus_Operation : ICalculate
    {
        public int CalculateAmount(int a, int b)
        {
            return a + b;
        }
    }

    public class Minus_Operation : ICalculate
    {
        public int CalculateAmount(int a, int b)
        {
            return a - b;
        }
    }


    public class CalculateClient
    {
        ICalculate calculate;
        public CalculateClient(ICalculate calculate)
        {
            this.calculate = calculate;
        }


        public int CalculateOperation(int a, int b)
        {
            return calculate.CalculateAmount(a, b);
        }

    }
        




}
