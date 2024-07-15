using Godot;

public partial class Player : Paddle
{
    public override void _Ready()
    {
        SetInitialSizes();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("ui_up"))
        {
            Position += Vector2.Up * Game.PADDLE_SPEED * (float)delta;
        }
        else if (Input.IsActionPressed("ui_down"))
        {
            Position += Vector2.Down * Game.PADDLE_SPEED * (float)delta;
        }

        Position = ClampY();
    }
}
