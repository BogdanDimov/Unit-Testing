using NUnit.Framework;
using Tasker.Models;

namespace Tasker.Tests.Models.TaskTests
{
    [TestFixture]
    public class ConstructorTests
    {
        public void Ctor_ShouldAssignDescription_WhenInvoked(string value)
        {
            // arrange && act
            var expected = "Valid description";
            var sut = new Task(expected);

            // assert
            Assert.AreEqual(expected, sut.Description);
        }
    }
}
