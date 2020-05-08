using FluentAssertions;
using NUnit.Framework;
using ParcelDelivery.ConsoleApp.Handlers;
using ParcelDelivery.Tests.Stubs;

namespace ParcelDelivery.Tests
{
    public class InsuranceHandlerTests
    {
        private InsuranceHandler _sut;

        [SetUp]
        public void BeforeEachTest()
        {
            _sut = new InsuranceHandler();
        }

        [Test]
        public void Handle_ShouldAskForApproval_IfNotAskedBeforeAndValueOver1000()
        {
            //  Arrange
            Parcel parcel = new Parcel();
            parcel.Value = 1000;

            //  Act
            var attempt = _sut.Handle(parcel);

            //  Assert
            attempt.Success.Should().BeFalse();
            attempt.Result.RequiresApproval.Should().BeTrue();
            attempt.Result.Parcel.Should().BeSameAs(parcel);
            attempt.Exception.Should().BeNull();
        }

        [Test]
        public void Handle_ShouldReturnException_IfApprovalDeclined()
        {
            //  Arrange
            Parcel parcel = new Parcel();
            parcel.Approved = false;

            //  Act
            var attempt = _sut.Handle(parcel);

            //  Assert
            attempt.Success.Should().BeFalse();
            attempt.Result.Should().BeNull();
            attempt.Exception.Should().BeOfType<ApprovalDeclinedException>();
        }

        [Test]
        public void Handle_ShouldMoveToNextHandler_IfUnder1000AndApprovalNotNeeded()
        {
            //  Arrange

            //  we don't want the test to fail due to no next handler being available.
            _sut.SetNext(new StubSuccessHander());

            Parcel parcel = new Parcel();

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