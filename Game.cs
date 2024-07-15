using Godot;
using System;

public partial class Game : Sprite2D
{
    [Signal]
    public delegate void Player1ScoredEventHandler();

    [Signal]
    public delegate void Player2ScoredEventHandler();

    internal const int PADDLE_SPEED = 500;

    private bool _gameIsStarted = false;

    public void Start()
    {
        GetNode<Timer>("BallTimer").Start();
        _gameIsStarted = true;
    }

    internal void SetOptions(GameOptions options)
    {
        GetNode<Player1>("Player1").SetOptions(options);
        GetNode<Player2>("Player2").SetOptions(options);
    }

    public void OnBallTimerTimeout()
    {
        GetNode<Ball>("Ball").NewBall();
    }

    public void OnBallHitLeft(Node2D _body)
    {
        GetNode<AudioStreamPlayer>("Score").Play();
        EmitSignal(SignalName.Player2Scored);
        GetNode<Timer>("BallTimer").Start();

    }

    public void OnBallHitRight(Node2D _body)
    {
        GetNode<AudioStreamPlayer>("Score").Play();
        EmitSignal(SignalName.Player1Scored);
        GetNode<Timer>("BallTimer").Start();
    }
}
