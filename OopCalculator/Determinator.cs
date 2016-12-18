using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OopCalculator
{
    
    class Determinator
    {
        public bool isDigit;

        public void DetermineIsDigit(char symbol)
        {
            isDigit = false;
            if (Char.IsDigit(symbol) || symbol.ToString() == Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                isDigit = true;
        }
    }
}
