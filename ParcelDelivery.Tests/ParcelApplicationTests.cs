using System;
using System.IO;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ParcelDelivery.Abstractions;
using ParcelDelivery.ConsoleApp;

namespace ParcelDelivery.Tests
{
    public class ParcelApplicationTests
    {
        [Test]
        public void ProcessFromFile_ShouldThrowFileNotFoundException_IfFileCannotBeFound()
        {
            //  Arrange
            var mockFileSystem = new Mock<IFileSystem>();
            mockFileSystem.Setup(x => x.FileExists(It.IsAny<string>())).Returns(false);

            var sut = new ParcelApplication(null, null, mockFileSystem.Object);

            //  Act
            Action act = () => sut.ProcessFromFile("c:\\fakefile.xml");
            
            //  Assert
            act.Should().Throw<FileNotFoundException>();
        }

        [TestCase(null)]
        [TestCase("")]
        public void ProcessFromFile_ShouldThrowArgumentNullException_IfFilePathIs(string filePath)
        {
            //  Arrange
            var sut = new ParcelApplication(null, null, null);

            //  Act
            Action act = () => sut.ProcessFromFile(filePath);
            
            //  Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}