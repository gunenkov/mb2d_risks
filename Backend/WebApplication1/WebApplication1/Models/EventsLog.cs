using System;

namespace WebApplication1.Models
{
    public class EventsLog
    {
        public int Id {  get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public bool IsExternalFactor { get; set; }
        public EventLogStatus Status { get; set; }
        public int EventId { get; set; }
        public int RiskId { get; set; }
    }
}
