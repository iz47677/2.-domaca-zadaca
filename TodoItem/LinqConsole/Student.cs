using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    public class Student : IEquatable<Student>
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public bool Equals(Student other)
        {
            if (this.Name == other.Name && this.Jmbag == other.Jmbag)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hashName = Name.GetHashCode();
            int hashJmbag = Jmbag.GetHashCode();

            return hashName ^ hashJmbag;
        }
    }

    public enum Gender
    {
        Male, Female
    }
}
