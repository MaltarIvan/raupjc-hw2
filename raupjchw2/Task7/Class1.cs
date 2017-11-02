using System;
using System.Linq;
using System.Threading.Tasks;

namespace Task7
{
    public class Class1
    {
        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumberAsync();
            int[] magicNumbers = result.Result;
            Console.WriteLine(magicNumbers.Sum());
        }
        private static async Task<int[]> GetTheMagicNumberAsync()
        {
            return await IKnowIGuyWhoKnowsAGuyAsync();
        }
        private static async Task<int[]> IKnowIGuyWhoKnowsAGuyAsync()
        {
            var task1 = IKnowWhoKnowsThisAsync(10);
            var task2 = IKnowWhoKnowsThisAsync(5);
            
            return await Task.WhenAll(task1, task2);
        }
        private static async Task<int> IKnowWhoKnowsThisAsync(int n)
        {
            return await FactorialDigitSum(n);
        }

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
