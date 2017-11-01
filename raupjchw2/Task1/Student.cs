using System;

namespace Task1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(Object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Student student = (Student)obj;
            return (Name == student.Name && Jmbag == student.Jmbag && Gender == student.Gender);
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode() * Name.GetHashCode() * Gender.GetHashCode(); 
        }

        public static bool operator ==(Student s1, Student s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(Student s1, Student s2)
        {
            return !s1.Equals(s2);
        }
    }

    public enum Gender
    {
        Male, Female
    }
}
