using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwizzBotDisco.Games.HorseRacing.Models
{
    public class RaceSettings
    {
        public int HorseCount { get; set; } = 8;
        // RaceDistance: 60 ≈ 20–30s; bump to 50 for ~20s, 70 for ~30s)
        public int RaceDistance  { get; set; } = 50;
        public int UpdateDelayMs { get; set; } = 1000;
        public int CoolDownMins  { get; set; } = 5;
        public int MinSpeed      { get; set; } = 4;
        public int MaxSpeed      { get; set; } = 10;
        public int MinStamina    { get; set; } = 3;
        public int MaxStamina    { get; set; } = 10;
        public int MinGrit       { get; set; } = 1;
        public int MaxGrit       { get; set; } = 10;

        /*
            ====================================
             How to Estimate Race Length (Seconds)
            ====================================

            Race time is determined by:
            1. RaceDistance  → total "units" to finish.
            2. Horse Speed   → units moved per tick (before fatigue).
            3. Stamina       → number of ticks at full speed.
            4. Grit          → % chance to ignore fatigue penalty each tick after stamina runs out.
            5. UpdateDelayMs → how long each tick is in real time.

            -------------------------------
            Basic Estimation Formula:
            -------------------------------
            1. Estimate average speed (AvgSpeed) based on your Speed, Stamina, and Grit ranges.
               - Example: Speed 4–10, avg ≈ 7 units/tick before fatigue.
               - Fatigue typically reduces speed by 1 after stamina ends.

            2. Estimate ticks to finish:
                  Ticks ≈ RaceDistance / AvgSpeed

            3. Convert ticks to seconds:
                  RaceTimeSec ≈ Ticks × (UpdateDelayMs / 1000)

            -------------------------------
            Example:
            -------------------------------
            Speed Range = 4–10 (avg ~7)
            Stamina Range = 3–10 (avg ~6 ticks at top speed)
            UpdateDelayMs = 1000
            RaceDistance = 80

            - First 6 ticks: speed ≈ 7 units/tick
            - Remaining ticks: speed ≈ 6 units/tick (fatigue penalty -1)

            Distance covered in first 6 ticks = 6 × 7 = 42 units
            Remaining distance = 80 - 42 = 38 units
            Ticks to cover remaining = 38 / 6 ≈ 6.33 ticks

            Total ticks ≈ 6 + 6.33 ≈ 12.33 ticks
            Race time ≈ 12.33 × 1s ≈ 12.3 seconds
        */
    }
}
