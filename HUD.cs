using Godot;

public partial class HUD : CanvasLayer
{
    [Signal]
    public delegate void StartGameEventHandler(bool singlePlayer);

    [Signal]
    public delegate void PausePressedEventHandler();

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
    }

    public void UpdateScores(int player1, int player2)
    {
        GetNode<Label>("Player1Score").Text = $"{player1}";
        GetNode<Label>("Player2Score").Text = $"{player2}";
    }

    public void ShowMessage(string text)
    {
        var message = GetNode<Label>("Message");
        message.Text = text;
        message.Show();

        GetNode<Timer>("MessageTimer").Start();
    }

    private void OnMessageTimerTimeout()
    {
        GetNode<Label>("Message").Hide();
    }

    public void OnStartButtonPressed(bool singlePlayer)
    {
        GetNode<CanvasLayer>("Menu").Hide();
        GetNode<Label>("Player1Score").Show();
        GetNode<Label>("Player2Score").Show();
        EmitSignal(SignalName.StartGame, singlePlayer);
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        if (Input.IsActionJustPressed("pause"))
        {
            EmitSignal(SignalName.PausePressed);
        }
    }
}
