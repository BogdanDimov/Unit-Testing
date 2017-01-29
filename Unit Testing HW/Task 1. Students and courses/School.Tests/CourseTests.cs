using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Tests
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudent_StudentsLimitReached_ThrowsInvalidOperationException()
        {
            // arrange
            var course = new Course();
            var students = new List<Student>();

            // act
            for (int i = 0; i < 50; i++)
            {
                course.AddStudent(new Student());
            }

            // assert handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStudent_StudentNotFound_ThrowsArgumentException()
        {
            // arrange
            var course = new Course();
            var student = new Student(10000, "Koko");

            // act
            course.RemoveStudent(student);

            // assert handled by ExpectedException
        }
    }
}