using Xunit;
using ReferralPortal;

namespace ReferralPortal.Tests;

public class SampleTrackerTests
{
    [Fact]
    public void Should_Send_Result_When_Ready_Approved_And_Secure()
    {
        var tracker = new SampleTracker();

        var result = tracker.TrackSample(
            1,
            1,
            "READY",
            true,
            true,
            true);

        Assert.Equal(
            "Final Result Sent Securely",
            result);
    }

    [Fact]
    public void Should_Return_NotApproved()
    {
        var tracker = new SampleTracker();

        var result = tracker.TrackSample(
            1,
            1,
            "READY",
            false,
            true,
            true);

        Assert.Equal(
            "Result Not Approved Yet",
            result);
    }

    [Fact]
    public void Should_Throw_AccessDenied()
    {
        var tracker = new SampleTracker();

        Assert.Throws<AccessDeniedException>(() =>
            tracker.TrackSample(
                1,
                2,
                "READY",
                true,
                true,
                true));
    }
}
