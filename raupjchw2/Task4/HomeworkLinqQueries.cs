using System;
using System.Linq;
using Task1;

namespace Task4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.OrderBy(i => i).GroupBy(i => i).Select(g => String.Format("Broj {0} ponavlja se {1} puta", g.Key, g.Count())).ToArray();
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.All(s => s.Gender == Gender.Male)).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.Count() < universityArray.Average(s => s.Students.Count())).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.All(s => s.Gender == Gender.Male) || u.Students.All(s => s.Gender == Gender.Female)).SelectMany(s => s.Students).Distinct().ToArray(); ;
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).GroupBy(s => s.Jmbag).Where(g => g.Count() >= 2).Select(y => y.First()).ToArray();
        }
    }
}
