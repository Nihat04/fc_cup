﻿using Microsoft.EntityFrameworkCore;

namespace FcCupApi.Models
{
    public enum TimeLineActionType
    {
        Goal,
        YellowCard,
        RedCard,
        Substitution,
        Injury
    }
    [Keyless]
    public class TimeLine
    {
        public int Minute { get; set; }
        public TimeLineActionType Type { get; set; }
        public Player Player { get; set; }
        public FootballerCard Footballer { get; set; }
        public List<FootballerCard>? OtherFootballers { get; set; }

    }
}
