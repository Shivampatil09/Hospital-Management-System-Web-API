using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginInformation : ControllerBase
    {
        [HttpGet]
        public List<User_Login_Information_Model> Getdata()
        {
            string qry = "select * from m_user_Login_information";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var unitInfo_list = new List<User_Login_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User_Login_Information_Model m = new User_Login_Information_Model()
                {
                    user_id = Convert.ToInt32(dt.Rows[i]["user_id"]),
                    user_name = dt.Rows[i]["user_name"].ToString(),
                    user_password = dt.Rows[i]["user_password"].ToString(),
                    user_confirm_password = dt.Rows[i]["user_confirm_password"].ToString(),
                    Employee_id = Convert.ToInt32(dt.Rows[i]["Employee_id"])
                };
                unitInfo_list.Add(m);
            }
            return unitInfo_list;
        }


        [HttpPost]
        public void PostData(User_Login_Information_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.user_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_user_Login_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@user_id", model.user_id);
            sqlcmd.Parameters.AddWithValue("@user_name", model.user_name);
            sqlcmd.Parameters.AddWithValue("@user_password", model.user_password);
            sqlcmd.Parameters.AddWithValue("@user_confirm_password", model.user_confirm_password);
            sqlcmd.Parameters.AddWithValue("@Employee_id", model.Employee_id);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);

            sqlcmd.ExecuteNonQuery();
        }
        [HttpDelete]
        public ActionResult DeleteData(int Id)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            string qry = "delete from m_user_Login_information where user_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_user_Login_information where user_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var unitInfo_list = new List<User_Login_Information_Model>();

            User_Login_Information_Model m = new User_Login_Information_Model()
            {
                user_id = Convert.ToInt32(dt.Rows[0]["user_id"]),
                user_name = dt.Rows[0]["user_name"].ToString(),
                user_password = dt.Rows[0]["user_password"].ToString(),
                user_confirm_password = dt.Rows[0]["user_confirm_password"].ToString(),
                Employee_id = Convert.ToInt32(dt.Rows[0]["Employee_id"])
            };
            unitInfo_list.Add(m);
            return Ok(unitInfo_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_user_Login_information where user_name like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var unitInfo_list = new List<User_Login_Information_Model>();

            User_Login_Information_Model m = new User_Login_Information_Model()
            {
                user_id = Convert.ToInt32(dt.Rows[0]["user_id"]),
                user_name = dt.Rows[0]["user_name"].ToString(),
                user_password = dt.Rows[0]["user_password"].ToString(),
                user_confirm_password = dt.Rows[0]["user_confirm_password"].ToString(),
                Employee_id = Convert.ToInt32(dt.Rows[0]["Employee_id"])
            };
            unitInfo_list.Add(m);
            return Ok(unitInfo_list);
        }
    }
}
