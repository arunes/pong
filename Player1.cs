public partial class Player1 : Paddle
{
    public override void _Process(double delta)
    {
        if (Options.Player1Control == ControlledByEnum.CPU)
        {
            CPUMove((float)delta);
        }
        else
        {
            PlayerMove((float)delta, "player1");
        }
    }
}
