using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumber()
        {
            var result = await IKnowIGuyWhoKnowsAGuy();
            return result;
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            var result10 = await IKnowWhoKnowsThis(10);
            var result5 = await IKnowWhoKnowsThis(5);
            return result10 + result5;
        }

        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            var result = await FactorialDigitSum(n);
            return result;
        }

        private static async Task<int> FactorialDigitSum(int n)
        {
            int factorial = 1;
            for (int i = 1; i <= n; i++)
                factorial *= i;
            int sum = 0;
            while (factorial > 0)
            {
                sum += (factorial % 10);
                factorial /= 10;
            }
            return sum;
        }
    }
}
