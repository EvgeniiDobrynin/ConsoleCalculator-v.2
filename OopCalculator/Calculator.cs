using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace OopCalculator
{
    public class Calculator
    {
        int begin;
        int end;
        public string Calculate(string expression)
        {
            string result;
            Parser parser = new Parser();
            List<CalcObject> list = new List<CalcObject>();
            CalcObject calcObject = new CalcObject();

            expression = ModifiedExpression(expression);

            if (expression == "")
            {
                result = "";
            }
            else
            {
                list = parser.ParseStringToListOfCalcObjects(expression);
                calcObject = Operate(list);
                result = calcObject.Value;
            }

            return result;
        }

        public CalcObject Operate(List<CalcObject> list)
        {
            int position; 

            while (list.Count > 1)
            {
                position = GetPosition(list);

                switch (list[position].GetType())
                {
                    case "OpenBracket":
                        begin = position + 1;
                        break;
                    case "CloseBracket":
                        end = position;
                        list[position] = new Calculator().Operate(list.GetRange(begin, end - begin));
                        list.RemoveRange(begin - 1, end - begin + 1);
                        begin = 0;
                        end = 0;
                        position = 0;
                        break;
                    case "Operator":
                        list[position] = list[position].Operate(list[position - 1].Value, list[position + 1].Value);
                        list.RemoveAt(position + 1);
                        list.RemoveAt(position - 1); 
                        break;
                    default:
                        break;
                }

               
            }

            return list[0];
        }

        private int GetPosition(List<CalcObject> list)
        {
            int priorityTemp;
            int position;

            priorityTemp = list[begin].GetPriority();
            position = begin;

            for (int i = begin; i < list.Count; i++)
            {
                if (priorityTemp < list[i].GetPriority())
                {
                    priorityTemp = list[i].GetPriority();
                    position = i;
                }
            }

            return position;
        }
        
        private string ModifiedExpression(string expression)
        {
            expression = expression.Replace(" ", "")
                .Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                .Replace(",", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            return expression;
        }
    }
}
