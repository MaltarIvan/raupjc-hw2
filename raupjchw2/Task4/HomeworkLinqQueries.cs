using System;
using System.Linq;
using Task1;

namespace Task4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            throw new NotImplementedException();
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
            return universityArray.SelectMany(u => u.Students).Distinct().Cast<Student>().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.All(s => s.Gender == Gender.Male) || u.Students.All(s => s.Gender == Gender.Female)).SelectMany(s => s.Students).Distinct().Cast<Student>().ToArray(); ;
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).GroupBy(s => s.Jmbag).Where(s => s.Count() >= 2).Cast<Student>().ToArray();
        }
    }
}
