using FluentAssertions;
using NUnit.Framework;
using ParcelDelivery.ConsoleApp.Handlers;
using ParcelDelivery.Tests.Stubs;

namespace ParcelDelivery.Tests
{
    public class MailHandlerTests
    {
        private MailHandler _sut;

        [SetUp]
        public void BeforeEachTest()
        {
            _sut = new MailHandler();
        }

        [Test]
        public void Handle_ShouldSendParcel_IfParcelWeightUnder1kg()
        {
            //  Arrange
            Parcel parcel = new Parcel();
            parcel.Weight = 0.9f;

            //  Act
            var attempt = _sut.Handle(parcel);

            //  Assert
            attempt.Success.Should().BeTrue();
            attempt.Result.Should().NotBeNull();
            attempt.Result.Parcel.Should().BeSameAs(parcel);
            attempt.Exception.Should().BeNull();
        }

        [Test]
        public void Handle_ShouldMoveToNextHandler_IfParcelWeightOver1kg()
        {
            //  Arrange

            //  we don't want the test to fail due to no next handler being available.
            _sut.SetNext(new StubSuccessHander());

            Parcel parcel = new Parcel();
            parcel.Weight = 1;

            //  Act
            var attempt = _sut.Handle(parcel);

            //  Assert
            attempt.Success.Should().BeTrue();
            attempt.Result.HandlerType.Should().Be(typeof(StubSuccessHander));
            attempt.Result.Parcel.Should().BeSameAs(parcel);
            attempt.Exception.Should().BeNull();
        }
    }
}