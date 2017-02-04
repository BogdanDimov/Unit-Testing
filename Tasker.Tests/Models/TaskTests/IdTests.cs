using NUnit.Framework;
using Tasker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasker.Tests.Models.TaskTests
{
    [TestFixture]
    public class IdTests
    {
        [TestCase(-1)]
        [TestCase(-10)]
        public void Id_ShouldThrowArgumentException_WhenPassedValueInInvalidRange(int value)
        {
            // Arrange
            var sut = new Task("Valid description");

            // Act && Assert
            Assert.Throws<ArgumentException> (() => sut.Id = value);
        }

        //[TestCase(-1)]
        //[TestCase(-10)]
        //public void Id_ShouldNotThrow_WhenPassedTests(int value)
        //{
        //    // Arrange
        //    var sut = new Task("Valid description");

        //    // Act && Assert
        //    Assert.Throws<ArgumentException>(() => sut.Id = value);
        //}

        [TestCase(0)]
        [TestCase(10)]
        public void Id_ShouldSetPassedValue_WhenPassedValueIsValid(int value)
        {
            // Arrange
            var sut = new Task("Valid description");

            // Act
            sut.Id = value;

            // Assert
            Assert.AreEqual(value, sut.Id);
        }
    }
}
