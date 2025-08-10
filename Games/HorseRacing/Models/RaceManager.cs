using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwizzBotDisco.Games.HorseRacing.Models
{
    public static class RaceManager
    {
        public static ConcurrentDictionary<ulong, Race> Races = new(); // raceId -> race
        public static bool BettingOpen { get; set; }
    }
}
