using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScadaApp
{
   public class ScaleValuesModel
    {
        public string ScaleValue1 { get; set; }
        public string ScaleValue2 { get; set; }

        public ScaleValuesModel()
        {

        }
        public ScaleValuesModel(DataRow row)
        {
            this.ScaleValue1 = row["ScaleValue1"].ToString();
            this.ScaleValue2 = row["ScaleValue2"].ToString();
        }
    }
}
