using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string AboutUs { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Vission { get; set; }
        public string Mission { get; set; }
        public string Plan1 { get; set; }
        public string Plan2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int FindUs { get; set; }
        public int UniqueProject { get; set; }
        public int Parts { get; set; }
        public int Achivements { get; set; }
        public int Countries { get; set; }
        public int ProjectInProgress { get; set; }
    }
}
