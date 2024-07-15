using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Feedback
{
    public class HomePageFeedBack
    {
        public int FbId { get; set; }

        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public int Rating { get; set; }

        public string Detail { get; set; } = null!;
    }
}
