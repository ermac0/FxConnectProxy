using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FxConnectProxy
{
    public class GetReportURLRequest
    {
        public AccountRow Account { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public ReportFormat Format { get; set; }

        public ReportType Type { get; set; }

        public ReportLanguage Language { get; set; }

        public int CodePage { get; set; }
    }
}
