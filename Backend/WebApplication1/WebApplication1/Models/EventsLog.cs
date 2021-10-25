using System;

namespace WebApplication1.Models
{
    public class EventsLog
    {
        public int Id {  get; set; }
        public DateTime Start { get; set; }
        public bool IsExternalFactor { get; set; }
        public bool IsSuccess { get; set; }
    }
}
