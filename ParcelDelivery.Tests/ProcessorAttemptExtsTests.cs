using System;
using FluentAssertions;
using NUnit.Framework;
using ParcelDelivery.Extensions;

namespace ParcelDelivery.Tests
{
    public class ProcessorAttemptExtsTests
    {
        [Test]
        public void GetParcelState_ShouldReturnNotSentWithNullResult_GivenFailedAttempt()
        {
            //  Arrange
            Attempt<ProcessorResult> attempt = Attempt<ProcessorResult>.Fail(null, new Exception(""));

            //  Act
            var (status, result) = attempt.GetParcelState();

            //  Assert
            status.Should().Be(ParcelState.NotSent);
            result.Should().BeNull();
        }

        [Test]
        public void GetParcelState_ShouldReturnSent_GivenSuccessfulObject()
        {
            //  Arrange
            var parcel = new Parcel();
            var obj = ProcessorResult.Sent(GetType(), parcel);

            Attempt<ProcessorResult> attempt = Attempt<ProcessorResult>.Succeed(obj);

            //  Act
            var (status, result) = attempt.GetParcelState();

            //  Assert
            status.Should().Be(ParcelState.Sent);
            result.Should().BeSameAs(obj);
        }

        [Test]
        public void GetParcelState_ShouldNeedApprovalWithResult_GivenApprovalObject()
        {
            //  Arrange
            var parcel = new Parcel();
            var obj = ProcessorResult.RequiresApprovalBeforeSending(GetType(), parcel);

            Attempt<ProcessorResult> attempt = Attempt<ProcessorResult>.Succeed(obj);

            //  Act
            var (status, result) = attempt.GetParcelState();

            //  Assert
            status.Should().Be(ParcelState.NeedsApproval);
            result.Should().BeSameAs(obj);
        }
    }
}