using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardSample.Shared
{
    //CANDIDATURE
    public class Applications
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public string CandidateName { get; set; } = "";
        public string Email { get; set; } = "";
        public string? CvUrl { get; set; }
        public string? Notes {  get; set; }
        public string Status { get; set; } = "pending"; //pending, rejected o highlighted
    }
}
