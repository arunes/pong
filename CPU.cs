using Godot;
using System;

public partial class CPU : Paddle
{
    private Vector2 _ballPosition;
    private float _ballDistance;
    private float _moveBy;

    public override void _Ready()
    {
        SetInitialSizes();
    }

    public override void _Process(double delta)
    {
        _ballPosition = GetNode<Ball>("../Ball").Position;
        _ballDistance = Position.Y - _ballPosition.Y;

        if (Math.Abs(_ballDistance) > (Game.PADDLE_SPEED * delta))
        {
            _moveBy = Game.PADDLE_SPEED * (float)delta * (_ballDistance / Math.Abs(_ballDistance));
        }
        else
        {
            _moveBy = _ballDistance;
        }

        Position -= Vector2.Down * _moveBy;
        Position = ClampY();
    }
}
