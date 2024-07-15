public enum ControlledByEnum { Player, CPU };
public enum DifficultyEnum { Easy, Normal, Hard };

public record GameOptions(
    ControlledByEnum Player1Control,
    ControlledByEnum Player2Control,
    DifficultyEnum Difficulty);
