using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScadaApp
{
    public class ScaleValueModel
    {
        public DateTime ThoiGian { get; set; }
        public double KhoiLuongCan { get; set; }
        public ScaleValueModel()
        {
                
        }
        public ScaleValueModel(DataRow row)
        {
            this.ThoiGian = Convert.ToDateTime(row["CreatedDate"].ToString());
            this.KhoiLuongCan = Convert.ToDouble(row["ScaleValue"].ToString());
        }
    }
}
