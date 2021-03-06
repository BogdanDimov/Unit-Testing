﻿using NUnit.Framework;
using System;
using System.IO;
using Tasker.Core.Providers;

namespace Tasker.Tests.Core.Provider.ConsoleLoggerTests
{
    [TestFixture]
    public class LogTests
    {
        [Test]
        public void Log_ShouldLogToConsole_WhenInvoked()
        {
            // arrange
            var message = "Pesho";
            var sut = new ConsoleLogger();

            var outputStream = new StringWriter();
            var defaultStream = Console.Out;
            Console.SetOut(outputStream);

            // act
            sut.Log(message);

            // Assert
            Assert.AreEqual(message + Environment.NewLine, outputStream.ToString());
            Console.SetOut(defaultStream);
        }
    }
}
