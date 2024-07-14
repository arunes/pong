using Godot;

public partial class Paddle : StaticBody2D
{
    internal float WinHeight = 0;
    internal float PaddleHeight = 0;

    internal void SetInitialSizes()
    {
        WinHeight = GetViewportRect().Size.Y;
        PaddleHeight = GetNode<ColorRect>("ColorRect").Size.Y;
    }

    internal Vector2 ClampY()
    {
        var newY = (float)Mathf.Clamp(Position.Y, PaddleHeight / 2.0, WinHeight - (PaddleHeight / 2.0));
        return newY != Position.Y
            ? new Vector2(Position.X, newY)
            : Position;
    }
}

