using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISafety.Models
{
    public class SubCategory
    {
        public string SubCatID { get; set; }
        public string CategoryID { get; set; }
        public string SubCatName { get; set; }
        public int AreaSize { get; set; }
        public int DangerLvl { get; set; }
    }
}
