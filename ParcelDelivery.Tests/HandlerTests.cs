using System;
using FluentAssertions;
using NUnit.Framework;
using ParcelDelivery.Tests.Stubs;

namespace ParcelDelivery.Tests
{
    public class HandlerTests
    {
        [Test]
        public void Handle_ShouldThrowNoSuitableHandlerException_IfNoNextHandlerAvailable()
        {
            //  Arrange
            var sut = new StubHander();

            //  Act
            Action act = () => sut.Handle(null);

            //  Assert
            act.Should().Throw<NoSuitableHandlerException>();
        }
    }
}