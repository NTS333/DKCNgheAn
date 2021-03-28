using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{

    public class DbAlarm
    {
        #region singleton
        private static DbAlarm _instance;
        public static DbAlarm Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbAlarm();
                }
                return _instance;
            }
            set => _instance = value;
        }
        public DbAlarm()
        {

        }
        #endregion


        public DataTable GetAll()
        {
            return DataProvider.Instance.ExecuteQuery("Select * from alarm1");
        }

        public List<AlarmModel> GetAllList()
        {
            List<AlarmModel> result = new List<AlarmModel>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from alarm1");

            foreach (DataRow item in data.Rows)
            {
                result.Add(new AlarmModel(item));
            }

            return result;
        }

        public DataTable GetDateTime(string fromDate, string toDate)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery($"select *from alarm1 where IncommingTime>='{fromDate}' and IncommingTime<='{toDate}'");
            }
            catch
            {
                return null;
            }
        }

        public List<AlarmModel> GetDateTimeList(string fromDate, string toDate)
        {
            try
            {
                List<AlarmModel> result = new List<AlarmModel>();

                DataTable data = DataProvider.Instance.ExecuteQuery($"select *from alarm1 where IncommingTime>='{fromDate}' and IncommingTime<='{toDate}'");

                foreach (DataRow item in data.Rows)
                {
                    result.Add(new AlarmModel(item));
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public int GetMaxId()
        {
            return DataProvider.Instance.ExecuteNonQuery_GetIdIdentity("sp_MixedGetMaxId");
        }
    }
}
