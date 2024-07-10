using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Admin
{
    public class AccountDashboardDTO
    {
        //account
        public int ActiveStudent { get; set; }
        public int InactiveStudent { get; set; }
        public int ActiveTutor { get; set; }
        public int InactiveTutor { get; set; }

        //booking status
        public int Complete { get; set; }
        public int Pending { get; set; }
        public int Approve { get; set; }
        public int Cancel { get; set; }
        public int Processing { get; set; }

        //feedback rating
        public double OneStar { get; set; }
        public double TwoStar { get; set; }
        public double ThreeStar { get; set; }
        public double FourStar { get; set; }
        public double FiveStar { get; set; }
    }
}

