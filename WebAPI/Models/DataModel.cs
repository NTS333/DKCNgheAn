using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class DataModel
    {
        #region tao ham dung cho model
        public DataModel()
        {

        }
        public DataModel(DataRow row)
        {
                this.dongMayNghienTho1 = !string.IsNullOrEmpty(row["DongMayNghienTho1"].ToString()) ? Convert.ToDouble(row["DongMayNghienTho1"]) : 0;
                this.dongMayNghienTho2 = !string.IsNullOrEmpty(row["DongMayNghienTho2"].ToString()) ? Convert.ToDouble(row["DongMayNghienTho2"]) : 0;
                this.dongMayNghienTinh = !string.IsNullOrEmpty(row["DongMayNghienTinh"].ToString()) ? Convert.ToDouble(row["DongMayNghienTinh"]) : 0;
                this.dongMayEp1 = !string.IsNullOrEmpty(row["DongMayEpVien1"].ToString()) ? Convert.ToDouble(row["DongMayEpVien1"]) : 0;
                this.dongMayEp2 = !string.IsNullOrEmpty(row["DongMayEpVien2"].ToString()) ? Convert.ToDouble(row["DongMayEpVien2"]) : 0;
                this.khoiLuongCan1 = !string.IsNullOrEmpty(row["KhoiLuongCan1"].ToString()) ? Convert.ToDouble(row["KhoiLuongCan1"]) : 0;
                this.khoiLuongCan2 = !string.IsNullOrEmpty(row["KhoiLuongCan2"].ToString()) ? Convert.ToDouble(row["KhoiLuongCan2"]) : 0;
                this.dateTime = row["DateTime"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["DateTime"]) : null;
        }
        #endregion

        private DateTime? dateTime;
        private double dongMayNghienTho1;
        private double dongMayNghienTho2;
        private double dongMayNghienTinh;
        private double dongMayEp1;
        private double dongMayEp2;
        private double khoiLuongCan1;
        private double khoiLuongCan2;

        public DateTime? DateTime { get => dateTime; set => dateTime = value; }//column WeightMaxEditor
        public double DongMayNghienTho1 { get => dongMayNghienTho1; set => dongMayNghienTho1 = value; }
        public double DongMayNghienTho2 { get => dongMayNghienTho2; set => dongMayNghienTho2 = value; }//column WeightMaxEditor
        public double DongMayNghienTinh { get => dongMayNghienTinh; set => dongMayNghienTinh = value; }//column WeightMaxEditor
        public double DongMayEp1 { get => dongMayEp1; set => dongMayEp1 = value; }//column WeightMaxEditor
        public double DongMayEp2 { get => dongMayEp2; set => dongMayEp2 = value; }//column WeightMaxEditor
        public double KhoiLuongCan1 { get => khoiLuongCan1; set => khoiLuongCan1 = value; }//column WeightMaxEditor
        public double KhoiLuongCan2 { get => khoiLuongCan2; set => khoiLuongCan2 = value; }//column WeightMaxEditor
    }
}
