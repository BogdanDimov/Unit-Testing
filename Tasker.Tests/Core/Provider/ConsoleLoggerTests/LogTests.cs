﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core.Providers;

namespace Tasker.Tests.Core.Provider.ConsoleLoggerTests
{
    [TestFixture]
    public class LogTests
    {
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