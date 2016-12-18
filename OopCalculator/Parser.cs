using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopCalculator
{
    class Parser
    {
        public List<CalcObject> ParseStringToListOfCalcObjects(string expression)
        {
            char[] charArray = expression.ToCharArray();
            char symbol;
            string number = "";
            Determinator determinator = new Determinator();
            List<CalcObject> list = new List<CalcObject>();
            CalcObject calcObject = new CalcObject();

            for (int i = 0; i < charArray.Length; i++)
            {
                symbol = charArray[i];
                determinator.DetermineIsDigit(symbol);

                if (!determinator.isDigit)
                {
                    if (number != "")
                        list.Add(calcObject.GetObject(number, !determinator.isDigit));

                    number = "";
                    list.Add(calcObject.GetObject(charArray[i].ToString(), determinator.isDigit));
                }
                else
                {
                    number += symbol;
                }

            }

            if (number != "")
                list.Add(calcObject.GetObject(number, determinator.isDigit));

            return list;
        }
    }
}
