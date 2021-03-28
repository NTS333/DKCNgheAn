using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{

    public class DbData
    {
        #region singleton
        private static DbData _instance;
        public static DbData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbData();
                }
                return _instance;
            }
            set => _instance = value;
        }
        public DbData()
        {

        }
        #endregion


        public DataTable GetAll()
        {
            return DataProvider.Instance.ExecuteQuery("Select * from data1");
        }

        public List<DataModel> GetAllList()
        {
            List<DataModel> result = new List<DataModel>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from data1");

            foreach (DataRow item in data.Rows)
            {
                result.Add(new DataModel(item));
            }

            return result;
        }

        public DataTable GetDateTime(string fromDate, string toDate)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery($"select *from data1 where DateTime>='{fromDate}' and DateTime<='{toDate}'");
            }
            catch
            {
                return null;
            }
        }

        public List<DataModel> GetDateTimeList(string fromDate, string toDate)
        {
            //try
            {
                List<DataModel> result = new List<DataModel>();

                DataTable data = DataProvider.Instance.ExecuteQuery($"select *from data1 where DateTime>='{fromDate}' and DateTime<='{toDate}'");

                foreach (DataRow item in data.Rows)
                {
                    result.Add(new DataModel(item));
                }

                return result;
            }
            //catch
            //{
            //    return null;
            //}
        }

        public DataTable GetTheoMay(string fromDate, string toDate, string tenMay)
        {
            try
            {
                DataTable result = null;
                if (tenMay == "NghienTho1")
                {
                    result = DataProvider.Instance.ExecuteQuery($"select ThoiGian,DongMayNghienTho1 from data1 where ThoiGian>='{fromDate}' and ThoiGian<='{toDate}'");
                }
                else if (tenMay == "NghienTho2")
                {
                    result = DataProvider.Instance.ExecuteQuery($"select ThoiGian,DongMayNghienTho2 from data1 where ThoiGian>={fromDate} and ThoiGian<={toDate}");
                }
                else if (tenMay == "NghienTinh")
                {
                    result = DataProvider.Instance.ExecuteQuery($"select ThoiGian,DongMayNghienTinh from data1 where ThoiGian>={fromDate} and ThoiGian<={toDate}");
                }
                else if (tenMay == "EpVien1")
                {
                    result = DataProvider.Instance.ExecuteQuery($"select ThoiGian,DongMayEp1 from data1 where ThoiGian>={fromDate} and ThoiGian<={toDate}");
                }
                else if (tenMay == "EpVien2")
                {
                    result = DataProvider.Instance.ExecuteQuery($"select ThoiGian,DongMayEp2 from data1 where ThoiGian>={fromDate} and ThoiGian<={toDate}");
                }
                else if (tenMay == "KLCan1")
                {
                    result = DataProvider.Instance.ExecuteQuery($"select ThoiGian,KhoiLuongCan1 from data1 where ThoiGian>={fromDate} and ThoiGian<={toDate}");
                }
                else if (tenMay == "KLCan2")
                {
                    result = DataProvider.Instance.ExecuteQuery($"select ThoiGian,KhoiLuongCan2 from data1 where ThoiGian>={fromDate} and ThoiGian<={toDate}");
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

        public int InsertData(DataModel _data)
        {
            int result = 0;
            result = DataProvider.Instance.ExecuteNonQuery($"insert into data1 (DongMayNghienTho1,DongMayNghienTho2,DongMayNghienTinh,DongMayEp1,DongMayEp2,KhoiLuongCan1,KhoiLuongCan2)" +
                $" values ({_data.DongMayNghienTho1},{_data.DongMayNghienTho2},{_data.DongMayNghienTinh},{_data.DongMayEp1},{_data.DongMayEp2},{_data.KhoiLuongCan1},{_data.KhoiLuongCan2})");
            return result;
        }
    }
}
