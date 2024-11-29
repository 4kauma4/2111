using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Model
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Message { get; set; }
        public int MasterID { get; set; }
        public int RequestID { get; set; }
    }
}
