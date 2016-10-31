using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };

            string[] strings = integers.GroupBy(i => i).Select(i => $"Broj {i.First()} ponavlja se {i.Count()} puta").Cast<string>().ToArray();

            foreach (string s in strings)
                Console.WriteLine(s);

            var list = new List<Student>()
            {
                new Student("Ivan", jmbag : "001234567")
            };
            var ivan = new Student("Ivan", jmbag : "001234567");

            bool anyIvanExists = list.Any(s => s.Equals(ivan));

            var list2 = new List<Student>()
            {
                new Student ("Ivan", jmbag : "001234567"),
                new Student ("Ivan", jmbag : "001234567")
            };

            var distinctStudents = list2.Distinct().Count();

            Console.WriteLine(anyIvanExists);
            Console.WriteLine(distinctStudents);

            University[] universities = GetAllCroatianUniversities();
            Student[] allCroatianStudents = universities.SelectMany(university => university.Students).Distinct().Cast<Student>().ToArray();
            Student[] croatianStudentsOnMultipleUniversities = universities.SelectMany(university => university.Students).
                GroupBy(students => students).Where(students => students.Count() > 1).Select(students => students.First()).Cast<Student>().ToArray();
            Student[] studentsOnMaleOnlyUniversities = //ne mogu...
        }
    }
}
