using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScadaApp
{
    public class ThoiGianChayMayModel
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public Double RunTimeTotal { get; set; } = 0;

        public ThoiGianChayMayModel()
        {

        }

        public ThoiGianChayMayModel(DataRow row)
        {
            this.Id = !string.IsNullOrEmpty(row["Id"].ToString()) ? Convert.ToInt32(row["Id"]) : 0;
            this.MachineName = row["May"].ToString();
            this.StartTime = row["StartTime"].ToString();
                this.StopTime = row["StopTime"].ToString();
            
            //this.TimeRun = row["TimeRun"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["TimeRun"]) : null;
            //this.TimeStop = row["TimeStop"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["TimeStop"]) : null;
            this.RunTimeTotal = !string.IsNullOrEmpty(row["RunTimeTotal"].ToString()) ? Convert.ToDouble(row["RunTimeTotal"]) : 0;
        }
    }
}
