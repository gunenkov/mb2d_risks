using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class BusinessService
    {
        public int Id { get; set;  }
        public string Name {  get; set; }
        public List<Operation> Operations {  get; set; }
    }
}
