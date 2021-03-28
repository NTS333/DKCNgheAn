using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/value")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("GetReportData/{data}/{fromDate}/{toDate}")]
        public IHttpActionResult Get(string data, DateTime fromDate, DateTime toDate)
        {
            if (data == "Data")
            {
                List<DataModel> result = DbData.Instance.GetDateTimeList(fromDate.ToString("yyyy-MM-dd HH:mm:ss"), toDate.ToString("yyyy-MM-dd HH:mm:ss"));

                return Ok("Select Data");
            }
            else
            {
                List<AlarmModel> result = DbAlarm.Instance.GetDateTimeList(fromDate.ToString("yyyy-MM-dd HH:mm:ss"), toDate.ToString("yyyy-MM-dd HH:mm:ss"));

                return Ok("Select Alarm");
            }

            return BadRequest("Data empty or sometime was wrong");
        }

        [HttpGet]
        [Route("Login/{userName}/{password}")]
        public IHttpActionResult Get(string userName, string password)
        {
            var pass = EncodeMD5.EncryptString(password, "convertPassEasyScada");
            DataTable userInfoTable = DataProvider.Instance.ExecuteQuery($"Select * from useraccount where userName='{userName}' and password='{pass}'");

            if (userInfoTable != null && userInfoTable.Rows.Count > 0)
            {
                List<AccountModel> result = new List<AccountModel>();
                result.Add(new AccountModel(userInfoTable.Rows[0]));

                return Ok(result);
            }

            return BadRequest("Login Fail!");
        }

        [HttpPost]
        [Route("post")]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut]
        [Route("UpdatePass/{id}/{newPass}")]
        public IHttpActionResult Put(int id, [FromBody] string newPass)
        {
            var pass = EncodeMD5.EncryptString(newPass, "convertPassEasyScada");

            if (DataProvider.Instance.ExecuteNonQuery($"update useraccount set password='{pass}' where id= {id}") > 0)
            {
                return Ok("Successful");
            }

            return BadRequest("Error");
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
