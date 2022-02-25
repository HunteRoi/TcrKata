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

    [Theory]
    [InlineData("down 1", 1)]
    [InlineData("down 2", 2)]
    [InlineData("down 3", 3)]
    public void ExecuteCommand_Should_IncrementAim_With_CommandDownOne(string command, int expectedAim)
    {
        this.submarine.ExecuteCommand(command);

        this.submarine.Aim.Should().Be(expectedAim);
    }

    [Theory]
    [InlineData("up 1", -1)]
    [InlineData("up 2", -2)]
    public void ExecuteCommand_Should_DecrementAim_WithCommandUpOne(string command, int expectedAim)
    {
        this.submarine.ExecuteCommand(command);

        this.submarine.Aim.Should().Be(expectedAim);
    }
    
    [Theory]
    [InlineData("down 1", 2)]
    [InlineData("down 2", 4)]
    public void ExecuteCommand_Should_IncrementAimTwice_Given_CommandDownOneIsReceivedTwice(string command, int expectedAim)
    {
        this.submarine.ExecuteCommand(command);
        
        this.submarine.ExecuteCommand(command);
        
        this.submarine.Aim.Should().Be(expectedAim);
    }
    
    [Theory]
    [InlineData("up 1", -2)]
    [InlineData("up 2", -4)]
    public void ExecuteCommand_Should_DecrementAimTwice_Given_CommandUpOneIsReceivedTwice(string command, int expectedAim)
    {
        this.submarine.ExecuteCommand(command);
        
        this.submarine.ExecuteCommand(command);
        
        this.submarine.Aim.Should().Be(expectedAim);
    }

    [Theory]
    [InlineData("forward 1", 1)]
    [InlineData("forward 2", 2)]
    public void ExecuteCommand_Should_IncrementPositionByOne_Given_ForwardOneCommandIsReceived(string command, int expectedPosition)
    {
        this.submarine.ExecuteCommand(command);

        this.submarine.Position.Should().Be(expectedPosition);
    }
    
    [Theory]
    [InlineData("forward 1", 2)]
    public void ExecuteCommand_Should_IncrementPositionTwice_Given_ForwardCommandIsReceivedTwice(string command, int expectedPosition)
    {
        this.submarine.ExecuteCommand(command);
        
        this.submarine.ExecuteCommand(command);

        this.submarine.Position.Should().Be(expectedPosition);
    }

    [Theory]
    [InlineData("down 1" ,"forward 1", 1)]
    [InlineData("down 2" ,"forward 2", 4)]
    public void ExecuteCommand_Should_IncreasedDepth_Given_AimIsPositiveAndCommandIsForward(string downCommand,string forwardCommand,int expectedDepth)
    {
        //test
        this.submarine.ExecuteCommand(downCommand);
        
        this.submarine.ExecuteCommand(forwardCommand);

        this.submarine.Depth.Should().Be(expectedDepth);
    }
}