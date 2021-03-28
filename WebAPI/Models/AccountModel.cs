using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public AccountModel()
        {

        }
        public AccountModel(DataRow row)
        {
            this.Id = !string.IsNullOrEmpty(row["Id"].ToString()) ? Convert.ToInt32(row["Id"]) : 0;
            this.userName = row["userName"].ToString();
            this.password = row["password"].ToString();
        }
    }
}