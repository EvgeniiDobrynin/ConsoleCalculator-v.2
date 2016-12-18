using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopCalculator
{
    class CalcBracket : CalcObject
    {
        public CalcBracket(string type, string value)
            : base(type, value)
        {

        }

        override protected CalcObject GetObject(string type, string value)
        {
            switch (value)
            {
                case "(":
                    return new CalcBracketOpen(type, value);
                case ")":
                    return new CalcOperatorClose(type, value);
                default:
                    return new CalcObject("Error", null);
            }
        }
        public override string GetType()
        {
            return "Bracket";
        }
    }
}
