using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Risk
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int OperationId { get; set; }
        public RiskStatus CurrentStatus { get; set; }
        public RiskStatus WantedStatus { get; set; }
        public List<Incident> Incidents { get; set;  }
        public List<Event> Events { get; set; }
        public int Damage {  get; set; }
        public int Prob { get; set; }
        public Operation Operation {  get; set; }
    }
}
