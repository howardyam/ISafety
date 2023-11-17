using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISafety.Models
{
    public class QuickReportWithSubCategory
    {
        public QuickReport QuickReport { get; set; }
        public SubCategory SubCategory { get; set; }
        public Category Category { get; set; }
    }
}
