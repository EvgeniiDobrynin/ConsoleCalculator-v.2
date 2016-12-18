using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopCalculator
{
    [Serializable()]
    class CalcNumber : CalcObject
    {
        public CalcNumber(string type, string value)
            : base(type, value)
        {

        }

        public override int GetPriority()
        {
            return 0;
        }

        public override string GetType()
        {
            return "Number";
        }
    }
}
