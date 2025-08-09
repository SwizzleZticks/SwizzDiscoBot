using SwizzBotDisco.Games.HorseRacing.Utils;

namespace SwizzBotDisco.Games.HorseRacing.Models;

public class Horse
{
    private static readonly Random _random = new();
    private readonly RaceSettings _settings;

    private string _name;
    private int _speed;
    private int _stamina;
    private int _grit;
    private int _position;
    private int _fatigue;

    public string Name => _name;
    public int Speed => _speed;
    public int Stamina => _stamina;
    public int Grit => _grit;
    public int Position
    {
        get => _position;
        set => _position = value;
    }

    public int Fatigue
    {
        get => _fatigue;
        set => _fatigue = value;
    }
    // Add one to each max value to keep it true
    public Horse(RaceSettings settings)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));

        _name = HorseNameGenerator.GetRandomName();
        _speed = _random.Next(_settings.MinSpeed, _settings.MaxSpeed + 1); 
        _stamina = _random.Next(_settings.MinStamina, _settings.MaxStamina + 1);
        _grit = _random.Next(_settings.MinGrit, _settings.MaxGrit + 1);
        _position = 0;
        _fatigue = 0;
    }
}
