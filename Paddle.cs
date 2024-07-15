using Godot;
using System;

public partial class Paddle : StaticBody2D
{
    private Vector2 _winSize;
    private Vector2 _ballPosition;
    private float _ballDistance;
    private float _moveBy;

    internal float PaddleHeight = 0;
    internal GameOptions Options = new(ControlledByEnum.CPU, ControlledByEnum.CPU, DifficultyEnum.Easy);

    public override void _Ready()
    {
        _winSize = GetViewportRect().Size;
        PaddleHeight = GetNode<ColorRect>("ColorRect").Size.Y;
    }

    internal void SetOptions(GameOptions options)
    {
        Options = options;
    }

    internal Vector2 ClampY()
    {
        var newY = (float)Mathf.Clamp(Position.Y, PaddleHeight / 2.0, _winSize.Y - (PaddleHeight / 2.0));
        return newY != Position.Y
            ? new Vector2(Position.X, newY)
            : Position;
    }

    internal void PlayerMove(float delta, string player)
    {
        if (Input.IsActionPressed($"{player}_up"))
        {
            Position += Vector2.Up * Game.PADDLE_SPEED * delta;
        }
        else if (Input.IsActionPressed($"{player}_down"))
        {
            Position += Vector2.Down * Game.PADDLE_SPEED * delta;
        }

        Position = ClampY();
    }

    internal void CPUMove(float delta)
    {
        _ballPosition = GetNode<Ball>("../Ball").Position;
        _ballDistance = Position.Y - _ballPosition.Y;

        if (Options.Difficulty == DifficultyEnum.Easy && _ballPosition.X < _winSize.X / 2)
        {
            return;
        }
        else if (Options.Difficulty == DifficultyEnum.Normal && _ballPosition.X < _winSize.X / 3)
        {
            return;
        }

        if (Math.Abs(_ballDistance) > (Game.PADDLE_SPEED * delta))
        {
            _moveBy = Game.PADDLE_SPEED * delta * (_ballDistance / Math.Abs(_ballDistance));
        }
        else
        {
            _moveBy = _ballDistance;
        }

        Position -= Vector2.Down * _moveBy;
        Position = ClampY();
    }
}

