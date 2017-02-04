using NUnit.Framework;
using System;
using Tasker.Models;

namespace Tasker.Tests.Models.TaskTests
{
    [TestFixture]
    public class DescriptionTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void Description_ShouldThrowArgumentNullException_WhenPassedNullOrEmptyValue(string value)
        {
            // arrange
            var sut = new Task("Valid description");

            // act & assert
            Assert.Throws<ArgumentNullException>(() => sut.Description = value);
        }
    }
}
