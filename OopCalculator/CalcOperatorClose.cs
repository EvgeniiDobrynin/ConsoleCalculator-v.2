using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopCalculator
{
    class CalcOperatorClose : CalcBracket
    {
        public CalcOperatorClose(string type, string value)
            : base(type, value)
        {

        }

        public override int GetPriority()
        {
            return 3;
        }

        public override string GetType()
        {
            return "CloseBracket";
        }
    }
}
