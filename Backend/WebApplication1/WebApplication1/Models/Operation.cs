using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Operation
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int BusinessServiceId {  get; set; }
        public List<Risk> Risks {  get; set; }  
        public BusinessService BusinessService {  get; set; }
    }
}
