using System;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;
using ParcelDelivery.ConsoleApp;
using ParcelDelivery.ConsoleApp.Abstractions;

namespace ParcelDelivery.Tests
{
    public class ConsoleApprovalProviderTests
    {
        [TestCase('y', ConsoleKey.Y, ExpectedResult = true)]
        [TestCase('n', ConsoleKey.N, ExpectedResult = false)]
        [TestCase('\r', ConsoleKey.Enter, ExpectedResult = false)]
        public bool RequestApproval_Given(char c, ConsoleKey key)
        {
            //  Arrange
            var consoleKey = new ConsoleKeyInfo(c, key, false, false, false);

            var mockConsole = new Mock<IConsole>();
            mockConsole.Setup(x => x.WriteLine(It.IsAny<string>()));
            mockConsole.Setup(x => x.ReadKey(It.IsAny<bool>())).Returns(consoleKey);

            Parcel parcel = new Parcel
            {
                Sender = new Sender(), 
                Receipient = new Receipient()
            };

            IApprovalProvider sut = new ConsoleApprovalProvider(NullLogger<ConsoleApprovalProvider>.Instance, mockConsole.Object);

            //  Act
            bool result = sut.RequestApproval(parcel);

            //  Assert
            return result;
        }
    }
}