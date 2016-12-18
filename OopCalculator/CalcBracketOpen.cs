using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopCalculator
{
    class CalcBracketOpen : CalcBracket
    {
        public CalcBracketOpen(string type, string value)
            : base(type, value)
        {

        }

        public override int GetPriority()
        {
            return 3;
        }

        public override string GetType()
        {
            return "OpenBracket";
        }
    }
}
