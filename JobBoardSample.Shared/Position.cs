using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardSample.Shared
{
    //POSIZIONI
    public class Position
    {
        public int Id {  get; set; }
        public string Title { get; set; } = "";
        public string Department { get; set; } = "";
        public string Location { get; set; } = "";
        public decimal SalaryRangeMin { get; set; }
        public decimal SalaryRangeMax { get; set; }
        public DateTime PublishedAtUtc { get; set; }
    }
}