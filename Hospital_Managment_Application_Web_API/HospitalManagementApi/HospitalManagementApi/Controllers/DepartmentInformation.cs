using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentInformation : ControllerBase
    {
        [HttpGet]
        public List<Department_Information_Model> Getdata()
        {
            string qry = "select * from m_department_information";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var department_list = new List<Department_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Department_Information_Model m = new Department_Information_Model()
                { 
                department_id = Convert.ToInt32(dt.Rows[i]["department_id"]),
                    department_start_date = Convert.ToDateTime(dt.Rows[i]["department_start_date"]),
                    department_code = dt.Rows[i]["department_code"].ToString(),
                    department_name = dt.Rows[i]["department_name"].ToString(),
                    deparment_address = dt.Rows[i]["deparment_address"].ToString(),
                    deparment_description = dt.Rows[i]["deparment_description"].ToString(),
                    hospital_id = Convert.ToInt32(dt.Rows[i]["hospital_id"])
                };
                department_list.Add(m);
            }
            return department_list;
        }

        [HttpPost]
        public  async void PostData(Department_Information_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.department_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_department_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@department_id", model.department_id);
            sqlcmd.Parameters.AddWithValue("@department_start_date", model.department_start_date);
            sqlcmd.Parameters.AddWithValue("@department_code", model.department_code);
            sqlcmd.Parameters.AddWithValue("@department_name", model.department_name);
            sqlcmd.Parameters.AddWithValue("@deparment_address", model.deparment_address);
            sqlcmd.Parameters.AddWithValue("@deparment_description", model.deparment_description);
            sqlcmd.Parameters.AddWithValue("@hospital_id", model.hospital_id);
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
            string qry = "delete from m_department_information where department_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_department_information where department_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var Department_list = new List<Department_Information_Model>();

            Department_Information_Model m = new Department_Information_Model()
            {
                department_id = Convert.ToInt32(dt.Rows[0]["department_id"]),
                department_start_date = Convert.ToDateTime(dt.Rows[0]["department_start_date"]),
                department_code = dt.Rows[0]["department_code"].ToString(),
                department_name = dt.Rows[0]["department_name"].ToString(),
                deparment_address = dt.Rows[0]["deparment_address"].ToString(),
                deparment_description = dt.Rows[0]["deparment_description"].ToString(),
                hospital_id = Convert.ToInt32(dt.Rows[0]["hospital_id"])
            };
            Department_list.Add(m);
            return Ok(Department_list);
        }

        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_department_information where department_name like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var Department_list = new List<Department_Information_Model>();

            Department_Information_Model m = new Department_Information_Model()
            {
                department_id = Convert.ToInt32(dt.Rows[0]["department_id"]),
                department_start_date = Convert.ToDateTime(dt.Rows[0]["department_start_date"]),
                department_code = dt.Rows[0]["department_code"].ToString(),
                department_name = dt.Rows[0]["department_name"].ToString(),
                deparment_address = dt.Rows[0]["deparment_address"].ToString(),
                deparment_description = dt.Rows[0]["deparment_description"].ToString(),
                hospital_id = Convert.ToInt32(dt.Rows[0]["hospital_id"])
            };
            Department_list.Add(m);
            return Ok(Department_list);
        }
    }
}
