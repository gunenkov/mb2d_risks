using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Incident
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int RiskId {  get; set; }
        public DateTime DateTime {  get; set; }
        public bool Ccorresponds { get; set; }
        public IncidentResult Result { get; set; }
        public List<Event> Events { get; set; }
        public Risk Risk { get; set; }
    }
}
