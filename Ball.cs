using Godot;

public partial class Ball : CharacterBody2D
{
    const float START_SPEED = 500;
    const float ACCELERATION = 50;
    const float MAX_Y_FACTOR = 0.6f;

    private Vector2 _winSize;
    private float _speed = START_SPEED;
    private Vector2 _direction;

    public override void _Ready()
    {
        _winSize = GetViewportRect().Size;
    }

    internal void NewBall()
    {
        Position = new Vector2(_winSize.X / 2, (float)GD.RandRange(200.0, _winSize.Y - 200));
        _speed = START_SPEED;
        _direction = RandomDirection();
    }

    private static Vector2 RandomDirection()
    {
        static int Direction() => GD.RandRange(0, 1) == 1 ? 1 : -1;

        var x = Direction();
        var y = GD.Randf() * Direction();

        return new Vector2(x, y).Normalized();
    }

    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(_direction * _speed * (float)delta);
        if (collision == null)
        {
            return;
        }

        GetNode<AudioStreamPlayer>("../PaddleHit").Play();

        var collider = collision.GetCollider();
        if (collider is Paddle paddle)
        {
            _speed += ACCELERATION;
            _direction = BounceFromPaddle(paddle);
            return;
        }

        _direction = _direction.Bounce(collision.GetNormal());
    }

    private Vector2 BounceFromPaddle(Paddle paddle)
    {
        var ballY = Position.Y;
        var paddleY = paddle.Position.Y;
        var distance = ballY - paddleY;

        var x = _direction.X > 0 ? -1 : 1;
        var y = (distance / (paddle.PaddleHeight / 2)) * MAX_Y_FACTOR;
        return new Vector2(x, y);
    }
}
