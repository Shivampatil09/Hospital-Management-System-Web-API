using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInformation : ControllerBase
    {
        [HttpGet]
        public List<Employee_Information_Model> Getdata()
        {
            string qry = "select * from m_employee_information";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var employee_list = new List<Employee_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Employee_Information_Model m = new Employee_Information_Model()
                {
                    employee_id = Convert.ToInt32(dt.Rows[i]["employee_id"]),
                    employee_code = dt.Rows[i]["employee_code"].ToString(),
                    employee_title = Convert.ToInt32(dt.Rows[i]["employee_title"]),
                    employee_gender = Convert.ToInt32(dt.Rows[i]["employee_gender"]),
                    employee_name = dt.Rows[i]["employee_name"].ToString(),
                    employye_designation = Convert.ToInt32(dt.Rows[i]["employye_designation"]),
                    employee_department = Convert.ToInt32(dt.Rows[i]["employee_department"]),
                    employee_dob = Convert.ToDateTime(dt.Rows[i]["employee_dob"]),
                    employee_joing_date = Convert.ToDateTime(dt.Rows[i]["employee_joing_date"]),
                    employee_Address = dt.Rows[i]["employee_Address"].ToString(),
                    employee_Address1 = dt.Rows[i]["employee_Address1"].ToString(),
                    employee_city = dt.Rows[i]["employee_city"].ToString(),
                    employee_pan = dt.Rows[i]["employee_pan"].ToString(),
                    employee_adharchard = dt.Rows[i]["employee_adharchard"].ToString(),
                    employee_alternet_no = dt.Rows[i]["employee_alternet_no"].ToString(),
                    employee_mobile = dt.Rows[i]["employee_mobile"].ToString(),
                    employee_email_id = dt.Rows[i]["employee_email_id"].ToString(),
                    employee_bank_name = Convert.ToInt32(dt.Rows[i]["employee_bank_name"]),
                    employee_account_no = dt.Rows[i]["employee_account_no"].ToString(),
                    employee_ifsc_code = dt.Rows[i]["employee_ifsc_code"].ToString(),
                    employee_branch = Convert.ToInt32(dt.Rows[i]["employee_branch"])
                };
                employee_list.Add(m);
            }
            return employee_list;
        }

        [HttpPost]
        public async void PostData(Employee_Information_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.employee_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_employee_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@employee_id", model.employee_id);
            sqlcmd.Parameters.AddWithValue("@employee_code", model.employee_code);
            sqlcmd.Parameters.AddWithValue("@employee_title", model.employee_title);
            sqlcmd.Parameters.AddWithValue("@employee_gender", model.employee_gender);
            sqlcmd.Parameters.AddWithValue("@employee_name", model.employee_name);
            sqlcmd.Parameters.AddWithValue("@employye_designation", model.employye_designation);
            sqlcmd.Parameters.AddWithValue("@employee_department", model.employee_department);
            sqlcmd.Parameters.AddWithValue("@employee_dob", model.employee_dob);
            sqlcmd.Parameters.AddWithValue("@employee_joing_date", model.employee_joing_date);
            sqlcmd.Parameters.AddWithValue("@employee_Address", model.employee_Address);
            sqlcmd.Parameters.AddWithValue("@employee_Address1", model.employee_Address1);
            sqlcmd.Parameters.AddWithValue("@employee_city", model.employee_city);
            sqlcmd.Parameters.AddWithValue("@employee_pan", model.employee_pan);
            sqlcmd.Parameters.AddWithValue("@employee_adharchard ", model.employee_adharchard);
            sqlcmd.Parameters.AddWithValue("@employee_alternet_no", model.employee_alternet_no);
            sqlcmd.Parameters.AddWithValue("@employee_mobile", model.employee_mobile);
            sqlcmd.Parameters.AddWithValue("@employee_email_id", model.employee_email_id);
            sqlcmd.Parameters.AddWithValue("@employee_bank_name", model.employee_bank_name);
            sqlcmd.Parameters.AddWithValue("@employee_account_no", model.employee_account_no);
            sqlcmd.Parameters.AddWithValue("@employee_ifsc_code", model.employee_ifsc_code);
            sqlcmd.Parameters.AddWithValue("@employee_branch", model.employee_branch);
            sqlcmd.Parameters.AddWithValue("@employee_photo", "");
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.Parameters.AddWithValue("@active_flag", model.active_flag);

            sqlcmd.ExecuteNonQuery();
        }
        [HttpDelete]
        public ActionResult DeleteData(int Id)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            string qry = "delete from m_employee_information where employee_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_employee_information where employee_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var employee_list = new List<Employee_Information_Model>();

            Employee_Information_Model m = new Employee_Information_Model()
            {
                employee_id = Convert.ToInt32(dt.Rows[0]["employee_id"]),
                employee_code = dt.Rows[0]["employee_code"].ToString(),
                employee_title = Convert.ToInt32(dt.Rows[0]["employee_title"]),
                employee_gender = Convert.ToInt32(dt.Rows[0]["employee_gender"]),
                employee_name = dt.Rows[0]["employee_name"].ToString(),
                employye_designation = Convert.ToInt32(dt.Rows[0]["employye_designation"]),
                employee_department = Convert.ToInt32(dt.Rows[0]["employee_department"]),
                employee_dob = Convert.ToDateTime(dt.Rows[0]["employee_dob"]),
                employee_joing_date = Convert.ToDateTime(dt.Rows[0]["employee_joing_date"]),
                employee_Address = dt.Rows[0]["employee_Address"].ToString(),
                employee_Address1 = dt.Rows[0]["employee_Address1"].ToString(),
                employee_city = dt.Rows[0]["employee_city"].ToString(),
                employee_pan = dt.Rows[0]["employee_pan"].ToString(),
                employee_adharchard = dt.Rows[0]["employee_adharchard"].ToString(),
                employee_alternet_no = dt.Rows[0]["employee_alternet_no"].ToString(),
                employee_mobile = dt.Rows[0]["employee_mobile"].ToString(),
                employee_email_id = dt.Rows[0]["employee_email_id"].ToString(),
                employee_bank_name = Convert.ToInt32(dt.Rows[0]["employee_bank_name"]),
                employee_account_no = dt.Rows[0]["employee_account_no"].ToString(),
                employee_ifsc_code = dt.Rows[0]["employee_ifsc_code"].ToString(),
                employee_branch = Convert.ToInt32(dt.Rows[0]["employee_branch"])
            };
            employee_list.Add(m);
            return Ok(employee_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_employee_information where employee_name like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var employee_list = new List<Employee_Information_Model>();

            Employee_Information_Model m = new Employee_Information_Model()
            {
                employee_id = Convert.ToInt32(dt.Rows[0]["employee_id"]),
                employee_code = dt.Rows[0]["employee_code"].ToString(),
                employee_title = Convert.ToInt32(dt.Rows[0]["employee_title"]),
                employee_gender = Convert.ToInt32(dt.Rows[0]["employee_gender"]),
                employee_name = dt.Rows[0]["employee_name"].ToString(),
                employye_designation = Convert.ToInt32(dt.Rows[0]["employye_designation"]),
                employee_department = Convert.ToInt32(dt.Rows[0]["employee_department"]),
                employee_dob = Convert.ToDateTime(dt.Rows[0]["employee_dob"]),
                employee_joing_date = Convert.ToDateTime(dt.Rows[0]["employee_joing_date"]),
                employee_Address = dt.Rows[0]["employee_Address"].ToString(),
                employee_Address1 = dt.Rows[0]["employee_Address1"].ToString(),
                employee_city = dt.Rows[0]["employee_city"].ToString(),
                employee_pan = dt.Rows[0]["employee_pan"].ToString(),
                employee_adharchard = dt.Rows[0]["employee_adharchard"].ToString(),
                employee_alternet_no = dt.Rows[0]["employee_alternet_no"].ToString(),
                employee_mobile = dt.Rows[0]["employee_mobile"].ToString(),
                employee_email_id = dt.Rows[0]["employee_email_id"].ToString(),
                employee_bank_name = Convert.ToInt32(dt.Rows[0]["employee_bank_name"]),
                employee_account_no = dt.Rows[0]["employee_account_no"].ToString(),
                employee_ifsc_code = dt.Rows[0]["employee_ifsc_code"].ToString(),
                employee_branch = Convert.ToInt32(dt.Rows[0]["employee_branch"])
            };
            employee_list.Add(m);
            return Ok(employee_list);
        }
    }
}
