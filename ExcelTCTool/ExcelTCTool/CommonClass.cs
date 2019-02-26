using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelTCTool
{
    public class DesignSRS
    {
        public int ID { get; set; }
        public int RowID {get;set;}
        public override string ToString()
        {
            return string.Format("Overlap -> {0} : SRS-{1}", RowID.ToString(), ID.ToString().PadLeft(4, '0'));
        }
    }
}
