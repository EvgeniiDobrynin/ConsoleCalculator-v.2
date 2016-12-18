using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение: ");
            string expression = Console.ReadLine();
            Calculator calculator = new Calculator();
            Console.WriteLine("Результат: " + calculator.Calculate(expression));
            Console.ReadKey();
        }
    }
}
