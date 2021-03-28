using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EasyScadaApp
{
    public class AlarmModel
    {
        public AlarmModel()
        {

        }
        public AlarmModel(DataRow row)
        {
            this.incommingTime = row["IncommingTime"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["IncommingTime"]) : null;
            this.name = row["Name"].ToString();
            this.alarmText = row["AlarmText"].ToString();
            this.alarmClass = row["AlarmClass"].ToString();
            this.alarmGroup = row["AlarmGroup"].ToString();
            this.triggerTag = row["TriggerTag"].ToString();
            this.value = row["Value"].ToString();
            this.limit = row["Limit"].ToString();
            this.compareMode = row["CompareMode"].ToString();
            this.state = row["State"].ToString();
            this.outgoingTime = row["OutgoingTime"].ToString();
            this.ackTime = row["AckTime"].ToString();
            this.alarmType = row["AlarmType"].ToString();
        }


        private string name;
        private DateTime? incommingTime;
        private string alarmText;
        private string alarmClass;
        private string alarmGroup;
        private string triggerTag;
        private string value;
        private string limit;
        private string compareMode;
        private string state;
        private string outgoingTime;
        private string ackTime;
        private string alarmType;

        public DateTime? IncommingTime { get => incommingTime; set => incommingTime = value; }
        public string Name { get => name; set => name = value; }
        public string AlarmText { get => alarmText; set => alarmText = value; }
        public string AlarmClass { get => alarmClass; set => alarmClass = value; }
        public string AlarmGroup { get => alarmGroup; set => alarmGroup = value; }
        public string TriggerTag { get => triggerTag; set => triggerTag = value; }
        public string Value { get => value; set => this.value = value; }
        public string Limit { get => limit; set => limit = value; }
        public string CompareMode { get => compareMode; set => compareMode = value; }
        public string State { get => state; set => state = value; }
        public string OutgoingTime { get => outgoingTime; set => outgoingTime = value; }
        public string AckTime { get => ackTime; set => ackTime = value; }
        public string AlarmType { get => alarmType; set => alarmType = value; }
    }
}
