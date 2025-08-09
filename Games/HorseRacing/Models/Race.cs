using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwizzBotDisco.Games.HorseRacing.Models
{
    public sealed class Race
    {
        private readonly RaceSettings _settings;

        public List<Horse> Horses { get; } = new();
        public DateTime StartTime { get; } = DateTime.UtcNow;

        public Race(RaceSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            AddHorses();
        }

        private void AddHorses()
        {
            for (int i = 0; i < _settings.HorseCount; i++)
            {
                Horses.Add(new Horse());
            }
        }
    }

}
