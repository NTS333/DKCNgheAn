using EasyScadaApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScadaApp
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
                return DataProvider.Instance.ExecuteQuery($"select * from data1 where DateTime >= '{fromDate}' and DateTime <= '{toDate}'");
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

                DataTable data = DataProvider.Instance.ExecuteQuery($"select * from data1 where DateTime >= '{fromDate}' and DateTime <= '{toDate}'");

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
            result = DataProvider.Instance.ExecuteNonQuery($"insert into data1 (DongMayNghienTho1,DongMayNghienTho2,DongMayNghienTinh,DongMayEp1,DongMayEp2)" +
                $" values ({_data.DongMayNghienTho1},{_data.DongMayNghienTho2},{_data.DongMayNghienTinh},{_data.DongMayEp1},{_data.DongMayEp2})");
            return result;
        }

        public int InsertDataScale(ScaleValuesModel _data, int scaleId)
        {
            int result = 0;
            if (scaleId == 1)
            {
                result = DataProvider.Instance.ExecuteNonQuery($"insert into khoiluongcan1 (ScaleValue)" +
                $" values ({_data.ScaleValue1})");
            }
            else
            {
                result = DataProvider.Instance.ExecuteNonQuery($"insert into khoiluongcan2 (ScaleValue)" +
                $" values ({_data.ScaleValue2})");
            }

            return result;
        }

        public List<ScaleValueModel> GetScaleValue(string fromDate, string toDate,string scalrNum)
        {
            List<ScaleValueModel> result = new List<ScaleValueModel>();
            DataTable _data = null;
            if (scalrNum=="1")
            {
                _data = DataProvider.Instance.ExecuteQuery($"select * from khoiluongcan1 where CreatedDate >= '{fromDate}' and CreatedDate <= '{toDate}'");
            }
            else
            {
                _data = DataProvider.Instance.ExecuteQuery($"select * from khoiluongcan2 where CreatedDate >= '{fromDate}' and CreatedDate <= '{toDate}'");
            }
            
            if (_data != null && _data.Rows.Count > 0)
            {
                foreach (DataRow item in _data.Rows)
                {
                    result.Add(new ScaleValueModel(item));
                }
            }
            return result;
        }
        public DataTable GetScaleValueDDataTable(string fromDate, string toDate, string scalrNum)
        {
            
            DataTable result = null;
            if (scalrNum == "1")
            {
                result = DataProvider.Instance.ExecuteQuery($"select CreatedDate as ThoiGian,ScaleValue as KhoiLuongCan from khoiluongcan1 where CreatedDate >= '{fromDate}' and CreatedDate <= '{toDate}'");
            }
            else
            {
                result = DataProvider.Instance.ExecuteQuery($"select CreatedDate as ThoiGian,ScaleValue as KhoiLuongCan from khoiluongcan2 where CreatedDate >= '{fromDate}' and CreatedDate <= '{toDate}'");
            }

            return result;
        }

        public List<ThoiGianChayMayModel> GetDateRunTimeList(string fromDate, string toDate, string machineName)
        {
            //try
            {
                List<ThoiGianChayMayModel> result = new List<ThoiGianChayMayModel>();
                string tenMay = "";

                if (machineName == "Tất cả")
                {
                    DataTable data = DataProvider.Instance.ExecuteQuery($"select * from thoigianchaymay where StartTime >= '{fromDate}' and StartTime <= '{toDate}'");
                    foreach (DataRow item in data.Rows)
                    {
                        result.Add(new ThoiGianChayMayModel(item));
                    }
                }
                else
                {
                    if (machineName == "Nghiền thô 1")
                    {
                        tenMay = "MayNghienTho1";
                    }
                    else if (machineName == "Nghiền thô 2")
                    {
                        tenMay = "MayNghienTho2";
                    }
                    else if (machineName == "Nghiền tinh")
                    {
                        tenMay = "MayNghienTinh";
                    }
                    else if (machineName == "Ép viên 1")
                    {
                        tenMay = "EpVien1";
                    }
                    else if (machineName == "Ép viên 2")
                    {
                        tenMay = "EpVien2";
                    }

                    DataTable data = DataProvider.Instance.ExecuteQuery($"select * from thoigianchaymay where StartTime >= '{fromDate}' " +
                        $"and StartTime <= '{toDate}' and May='{tenMay}'");
                    foreach (DataRow item in data.Rows)
                    {
                        result.Add(new ThoiGianChayMayModel(item));
                    }
                }

                return result;
            }
            //catch
            //{
            //    return null;
            //}
        }

        public DataTable GetRunTime(string fromDate, string toDate, string machineName)
        {
            DataTable result = null;
            string tenMay = "";

            if (machineName == "Tất cả")
            {
                result = DataProvider.Instance.ExecuteQuery($"select * from thoigianchaymay where StartTime >= '{fromDate}' and StartTime <= '{toDate}'");
            }
            else
            {
                if (machineName == "Nghiền thô 1")
                {
                    tenMay = "MayNghienTho1";
                }
                else if (machineName == "Nghiền thô 2")
                {
                    tenMay = "MayNghienTho2";
                }
                else if (machineName == "Nghiền tinh")
                {
                    tenMay = "MayNghienTinh";
                }
                else if (machineName == "Ép viên 1")
                {
                    tenMay = "EpVien1";
                }
                else if (machineName == "Ép viên 2")
                {
                    tenMay = "EpVien2";
                }

                result = DataProvider.Instance.ExecuteQuery($"select * from thoigianchaymay where StartTime >= '{fromDate}' and StartTime <= '{toDate}' and May='{tenMay}'");
            }

            return result;
        }

        public int InsertDataTimeRun(ThoiGianChayMayModel _data)
        {
            int result = 0;
            result = DataProvider.Instance.ExecuteNonQuery($"insert into thoigianchaymay (May,StartTime)" +
                $" values ('{_data.MachineName}','{_data.StartTime}')");
            return result;
        }

        public int UpdateTimeRun(ThoiGianChayMayModel _data)
        {
            int result = 0;

            result = DataProvider.Instance.ExecuteNonQuery($"update thoigianchaymay set StopTime= '{_data.StopTime}', RunTimeTotal = { _data.RunTimeTotal} where Id= {_data.Id}");

            return result;
        }

        public int GetMaxIdTimeRun()
        {
            int result = 0;

            DataTable _data = DataProvider.Instance.ExecuteQuery($"select Id from thoigianchaymay order by Id desc limit 1");
            if (_data != null && _data.Rows.Count > 0)
            {
                result = Convert.ToInt32(_data.Rows[0]["Id"].ToString());
            }
            return result;
        }
    }
}
