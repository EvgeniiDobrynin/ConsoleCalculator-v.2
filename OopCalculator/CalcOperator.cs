using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopCalculator
{
    class CalcOperator : CalcObject
    {
        public CalcOperator(string type, string value)
            : base(type, value)
        {
            
        }

        override protected CalcObject GetObject(string type, string value)
        {
            switch (value)
            {
                case "+":
                    return new CalcOperatorSum(type, value);                    
                case "-":
                    return new CalcOperatorSubtract(type, value);
                case "*":
                    return new CalcOperatorMultiply(type, value);
                case "/":
                    return new CalcOperatorDivide(type, value);
                default:
                    return new CalcObject("Error", null);
            }
        }

        override public CalcObject Operate(string num1, string num2)
        {
            return new CalcObject("Error", null);
        }

        public override string GetType()
        {
            return "Operator";
        }
    }
}
