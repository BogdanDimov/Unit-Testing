using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private List<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public void AddStudent(Student s)
        {
            //if (s == null)
            //{
            //    throw new ArgumentException("Cannot add null students.");
            //}

            if (students.Count == 29)
            {
                throw new InvalidOperationException("Course must contain less than 30 students.");
            }

            students.Add(s);
        }

        public void RemoveStudent(Student s)
        {
            if (students.Contains(s) == false)
            {
                throw new ArgumentException("Cannot find the student to be removed.");
            }

            students.Remove(s);
        }
    }
}
