using Godot;

public partial class Main : Sprite2D
{
    private bool _isSinglePlayer = false;
    private int _player1Score = 0;
    private int _player2Score = 0;

    public override void _Ready()
	{
	}

	public override void _Process(double delta)
    {
    }

    public void Player1Scored()
    {
        _player1Score++;
        var hud = GetNode<HUD>("HUD");
        hud.UpdateScores(_player1Score, _player2Score);
    }

    public void Player2Scored()
    {
        _player2Score++;
        var hud = GetNode<HUD>("HUD");
        hud.UpdateScores(_player1Score, _player2Score);
    }

    public void NewGame(bool singlePlayer)
    {
        _player1Score = 0;
        _player2Score = 0;
        _isSinglePlayer = singlePlayer;

        var hud = GetNode<HUD>("HUD");
        hud.UpdateScores(_player1Score, _player2Score);
        hud.ShowMessage("Get Ready!");
        GetNode<Game>("Game").Show();
        GetNode<Timer>("StartTimer").Start();
        
        // reset resources and start music
    }

    private void OnStartTimerTimeout()
    {
        var game = GetNode<Game>("Game");
        game.Start(_isSinglePlayer);
    }
}
