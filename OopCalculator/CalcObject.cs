using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopCalculator
{
    public class CalcObject
    {
        protected string type;
        protected string val;

        private static readonly Dictionary<string, string> DeterminationOfTypeByValue = new Dictionary<string, string>
        {
            {"+", "Operator"},
            {"-", "Operator"},
            {"*", "Operator"},
            {"/", "Operator"},
            {"(", "OpenBracket"},
            {")", "CloseBracket"}            
        };
        public string Type
        {
            get { return type; }
            set { value = type; }
        }
        public string Value
        {
            get { return val; }
            set { value = val; }
        }

        public CalcObject()
        {

        }

        public CalcObject(string type, string value)
        {
            this.type = type;
            this.val = value;
        }

        public override string ToString()
        {
            return String.Format("Object:= Type: {0}; Value: {1}", Type.ToString(), Value);
        }

        virtual protected CalcObject GetObject(string type, string value)
        {
            switch (type)
            {
                case "Number":
                    CalcNumber calcNumber = new CalcNumber(type, value);
                    return calcNumber;
                case "Operator":
                    CalcOperator calcOperator = new CalcOperator(type, value);
                    return calcOperator.GetObject(type, value);
                case "OpenBracket":
                    CalcBracket openBracket = new CalcBracket(type, value);
                    return openBracket.GetObject(type, value);
                case "CloseBracket":
                    CalcBracket closeBracket = new CalcBracket(type, value);
                    return closeBracket.GetObject(type, value);
                default:
                    return new CalcObject("Error", null);
            }
        }

        virtual public CalcObject Operate(string p1, string p2)
        {
            return new CalcObject("Error", null);
        }

        virtual public int GetPriority()
        {
            return 0;
        }
        
        virtual public string GetType()
        {
            return "CalcObject";
        }

        internal CalcObject GetObject(string value, bool isNumber)
        {
            if (isNumber)
                return GetObject("Number", value);
            else
                return GetObject(DeterminationOfTypeByValue[value], value);
        }
    }
}
