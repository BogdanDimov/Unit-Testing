using Moq;
using NUnit.Framework;
using System;
using Tasker.Core;
using Tasker.Models.Contracts;
using Tasker.Tests.Core.TaskManagerTests.Fakes;

namespace Tasker.Tests.Core.TaskManagerTests
{
    [TestFixture]
    public class AddTests
    {
        [Test]
        public void Add_ShouldThrowArgumentNullException_WhenPassedNullValue()
        {
            var idProviderStub = new Mock<IIdProvider>();
            var taskStub = new Mock<ITask>();
            var consoleLoggerStub = new Mock<ILogger>();

            var sut = new TaskManager(idProviderStub.Object, consoleLoggerStub.Object);

            Assert.Throws<ArgumentNullException>(() => sut.Add(taskStub.Object));
        }

        [Test]
        public void Add_ShouldAssignIdToProvidedTask_WhenInvalidTaskIsPassed()
        {
            // arrange
            var expectedValue = 5;
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStub = new Mock<ILogger>();
            var taskMock = new Mock<ITask>();

            var sut = new TaskManager(idProviderStub.Object, consoleLoggerStub.Object);

            idProviderStub.Setup(x => x.NextId()).Returns(expectedValue);
            // act
            sut.Add(taskMock.Object);

            //assert
            taskMock.VerifySet(x => x.Id = 5);
        }

        [TestCase(0)]
        [TestCase(5)]
        public void Add_ShouldAssignIdToProvidedTask_WhenValidTaskIsPassed(int expectedValue)
        {
            // arrange
            var taskMock = new Mock<ITask>();
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStub = new Mock<ILogger>();
            idProviderStub.Setup(x => x.NextId()).Returns(expectedValue);

            var sut = new TaskManager(idProviderStub.Object, consoleLoggerStub.Object);

            // act
            sut.Add(taskMock.Object);

            //assert
            taskMock.VerifySet(x => x.Id = expectedValue);
        }

        [Test]
        public void Add_ShouldLogMessage_WhenAddedProvidedTaskToCollection()
        {
            // arrange
            var taskStub = new Mock<ITask>();
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerMock = new Mock<ILogger>();

            var sut = new TaskManager(idProviderStub.Object, consoleLoggerMock.Object);

            sut.Add(taskStub.Object);

            consoleLoggerMock.Verify(x => x.Log("Pesho"), Times.Once);
        }

        [Test]
        public void Add_ShouldAddTaskToCollection_WhenProvidedTasksIsValid()
        {
            // arrange
            var taskStub = new Mock<ITask>();
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStub = new Mock<ILogger>();

            var sut = new TaskManagerFake(idProviderStub.Object, consoleLoggerStub.Object);

            sut.Add(taskStub.Object);

            Assert.That(() => sut.ExposedTasks.Contains(taskStub.Object));
        }
    }
}
