using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models {
    public class ShowingModel {
        public DateTime Start { get; set; }
        public string Movie { get; set; }
        public string Room { get; set; }
        public bool Is3D { get; set; }
    }
}