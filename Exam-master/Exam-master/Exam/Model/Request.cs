using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Model
{
    public class Request
    {
        public int RequestID { get; set; }
        public DateTime StartDate { get; set; }
        public string OrgTechType { get; set; }
        public string OrgTechModel { get; set; }
        public string ProblemDescription { get; set; }
        public string RequestStatus { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string RepairParts { get; set; }
        public int MasterID { get; set; }
        public int ClientID { get; set; }
    }
}
