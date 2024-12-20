using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TestWebAPI.Models.Client;
using TestWebAPI.Models.Entity;

namespace TestWebAPI.Controllers
{
    [ApiController]
    public class MyOfficeController : Controller
    {
        [Route("/MyOffice/Insert")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Insert([FromBody] AddMyOfficeData data)
        {
            try
            {
                TestContext db = new TestContext();
                var inputParam = new SqlParameter("@InputParam", SqlDbType.NVarChar) { Value = "MyOffice_ACPD" };
                var outputParam = new SqlParameter("@OutputParam", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };

                // 執行 Stored Procedure
                db.Database.ExecuteSqlRaw("EXEC dbo.NEWSID @InputParam, @OutputParam OUTPUT", inputParam, outputParam);

                // 從輸出參數中取得值
                string newsid = outputParam.Value?.ToString() ?? string.Empty;
                db.MyOffice_ACPD.Add(new MyOffice_ACPD
                {
                    ACPD_SID = newsid,
                    ACPD_Cname = data.ACPD_Cname,
                    ACPD_Email = data.ACPD_Email,
                    ACPD_Ename = data.ACPD_Ename,
                    ACPD_LoginID = data.ACPD_LoginID,
                    ACPD_LoginPWD = data.ACPD_LoginPWD,
                    ACPD_Memo = data.ACPD_Memo,
                    ACPD_NowDateTime = DateTime.Now,
                    ACPD_NowID = data.ACPD_NowID,
                    ACPD_Sname = data.ACPD_Sname,
                    ACPD_Status = 0,
                    ACPD_Stop = false,
                    ACPD_StopMemo = string.Empty
                });
                db.SaveChanges();
                return Ok("OK,ID=" + newsid);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [Route("/MyOffice/Update")]
        [AllowAnonymous]
        [HttpPost]public IActionResult Update([FromBody] UpdateMyOfficeData data)
        {
            try
            {
                TestContext db = new TestContext();
                MyOffice_ACPD? ma = db.MyOffice_ACPD.Where(x => x.ACPD_SID == data.SID).FirstOrDefault();
                if (ma != null)
                {
                    ma.ACPD_Memo= data.ACPD_Memo;
                    ma.ACPD_Stop= data.ACPD_Stop;
                    ma.ACPD_StopMemo= data.ACPD_StopMemo;
                    ma.ACPD_Cname= data.ACPD_Cname;
                    ma.ACPD_Ename= data.ACPD_Ename;
                    ma.ACPD_Email=data.ACPD_Email;
                    ma.ACPD_LoginPWD= data.ACPD_LoginPWD;
                    ma.ACPD_Ename=data.ACPD_Ename;
                    ma.ACPD_LoginID= data.ACPD_LoginID;
                    ma.ACPD_LoginPWD=data.ACPD_LoginPWD;
                    ma.ACPD_Sname= data.ACPD_Sname;
                    ma.ACPD_Status= data.ACPD_Status;
                    ma.ACPD_UPDDateTime = DateTime.Now;
                    ma.ACPD_UPDID = data.ACPD_UPDID;
                    db.SaveChanges();
                    return Ok("OK");
                }
                else
                {
                    return Ok("Data not found");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [Route("/MyOffice/Get")]
        [AllowAnonymous]
        [HttpPost]public IActionResult Get([FromBody] DeleteMyOfficeData data)
        {
            try
            {
                TestContext db = new TestContext();
                MyOffice_ACPD? ma = db.MyOffice_ACPD.Where(x => x.ACPD_SID == data.SID).FirstOrDefault();
                if (ma != null)
                {
                    return Ok(ma);
                }
                else
                {
                    return Ok("Data not found");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [Route("/MyOffice/Delete")][AllowAnonymous][HttpPost]public IActionResult Delete([FromBody] DeleteMyOfficeData data)
        {
            try
            {
                TestContext db = new TestContext();
                MyOffice_ACPD? ma=db.MyOffice_ACPD.Where(x=>x.ACPD_SID==data.SID).FirstOrDefault();
                if (ma != null)
                {
                    db.MyOffice_ACPD.Remove(ma);
                    db.SaveChanges();
                    return Ok("OK");
                }
                else
                {
                    return Ok("Data not found");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
