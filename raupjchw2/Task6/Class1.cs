using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task6
{
    public class Class1
    {
        private static async Task<int> FactorialDigitSum(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }
            int sum = 0;
            await Task.Run(() =>
            {
                int result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
                while (result > 0)
                {
                    sum += result % 10;
                    result /= 10;
                }
            });
            return sum;
        }
    }
}
