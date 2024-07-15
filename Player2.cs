public partial class Player2 : Paddle
{
    public override void _Process(double delta)
    {
        if (Options.Player2Control == ControlledByEnum.CPU)
        {
            CPUMove((float)delta);
        }
        else
        {
            PlayerMove((float)delta, "player2");
        }
    }
}
