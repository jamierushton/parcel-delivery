using System;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace ParcelDelivery.Tests
{
    public class ParcelProcessorTests
    {
        [Test]
        public void Process_ShouldArgumentNullException_IfContainerIsNull()
        {
            //  Arrange
            var sut = new ParcelProcessor(NullLogger<ParcelProcessor>.Instance, null, null);

            //  Act
            Action act = () => sut.Process(null);
            
            //  Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}