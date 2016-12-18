using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopCalculator
{
    class CalcOperatorDivide : CalcOperator
    {
        public CalcOperatorDivide(string type, string value)
            : base(type, value)
        {

        }

        public override CalcObject Operate(string str1, string str2)
        {
            double num1 = Convert.ToDouble(str1);
            double num2 = Convert.ToDouble(str2);
            double result = num1 / num2;

            return new CalcNumber("Number", Convert.ToString(result));
        }

        public override int GetPriority()
        {
            return 2;
        }
    }
}
