using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WETwebApp.Models;

namespace WETwebApp.ViewModels
{
    public class ManagementViewModel
    {
        public string WPnumber { get; set; }
        public string LatestVisit { get; set; }
        public DateTime? VisitDate { get; set; }
        public string HESarea { get; set; }
        public string HESbatch { get; set; }
        public bool VisitComplete { get; set; }
        public string MonitorStatus { get; set; }
    }
}