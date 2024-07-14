using Godot;
using System;

public partial class Main : Sprite2D
{
    internal const int PADDLE_SPEED = 500;

    private int _playerScore = 0;
	private int _cpuScore = 0;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public void OnBallTimerTimeout()
	{
		GetNode<Ball>("Ball").NewBall();
	}

    public void OnBallHitLeft(Node2D body)
    {
        _cpuScore++;
        GetNode<Timer>("BallTimer").Start();
        GetNode<Label>("HUD/CPUScore").Text = $"{_cpuScore}";
    }

    public void OnBallHitRight(Node2D body)
    {
        _playerScore++;
        GetNode<Timer>("BallTimer").Start();
        GetNode<Label>("HUD/PlayerScore").Text = $"{_playerScore}";
    }
}
