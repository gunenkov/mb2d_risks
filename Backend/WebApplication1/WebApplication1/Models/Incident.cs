using System;

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
    }
}
