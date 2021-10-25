﻿using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Event
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int RiskId { get; set; }
        public int DurationInSeconds {  get; set; }
        public EventsLog EventsLog { get; set; }
        public int Value { get; set; }
    }
}
