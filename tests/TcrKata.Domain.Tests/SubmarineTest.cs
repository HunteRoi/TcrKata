using FluentAssertions;
using Xunit;

namespace TcrKata.Domain.Tests;

public class SubmarineTest
{
    private readonly Submarine submarine;

    public SubmarineTest()
    {
        this.submarine = new Submarine();
    }

    [Fact]
    public void SomeFakeTest()
    {
        this.submarine.Should().NotBeNull();
    }

    [Fact]
    public void Aim_Should_BeInitializedWithZero()
    {
        this.submarine.Aim.Should().Be(0);
    }

    [Fact]
    public void Position_Should_BeInitializedWithZero()
    {
        this.submarine.Position.Should().Be(0);
    }

    [Fact]
    public void Depth_Should_BeInitializedWithZero()
    {
        this.submarine.Depth.Should().Be(0);
    }
}