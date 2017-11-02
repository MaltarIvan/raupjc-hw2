using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task6
{
    public class Class1
    {

        //async function that caltulates the fractoril of n
        private static async Task<int> FactorialDigitSum(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }
            int result = 1;
            await Task.Run(() =>
            {
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
            });
            return result;
        }
    }
}
