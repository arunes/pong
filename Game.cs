using Godot;
using System;

public partial class Game : Sprite2D
{
    [Signal]
    public delegate void Player1ScoredEventHandler();

    [Signal]
    public delegate void Player2ScoredEventHandler();

    internal const int PADDLE_SPEED = 500;

    public void Start(bool singlePlayer)
    {
        GetNode<Timer>("BallTimer").Start();
    }

    public void OnBallTimerTimeout()
    {
        GetNode<Ball>("Ball").NewBall();
    }

    public void OnBallHitLeft(Node2D _body)
    {
        EmitSignal(SignalName.Player2Scored);
        GetNode<Timer>("BallTimer").Start();
        
    }

    public void OnBallHitRight(Node2D _body)
    {
        EmitSignal(SignalName.Player1Scored);
        GetNode<Timer>("BallTimer").Start();
    }
}
