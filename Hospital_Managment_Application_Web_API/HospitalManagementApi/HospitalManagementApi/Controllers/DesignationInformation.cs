using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationInformation : ControllerBase
    {
        [HttpGet]
        public List<Designation_Information_Model> Getdata()
        {
            string qry = "select * from m_designation_information";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var designation_list = new List<Designation_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Designation_Information_Model m = new Designation_Information_Model()
                {
                    designation_id = Convert.ToInt32(dt.Rows[i]["designation_id"]),
                    designation_name = dt.Rows[i]["designation_name"].ToString(),
                    designation_qualification = dt.Rows[i]["designation_qualification"].ToString(),
                    designation_description = dt.Rows[i]["designation_description"].ToString(),
                    designation_code = dt.Rows[i]["designation_code"].ToString()
                };
                designation_list.Add(m);
            }
            return designation_list;
        }

        [HttpPost]
        public async void PostData(Designation_Information_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.designation_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_designation_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@designation_id", model.designation_id);
            sqlcmd.Parameters.AddWithValue("@designation_code", model.designation_code);
            sqlcmd.Parameters.AddWithValue("@designation_name", model.designation_name);
            sqlcmd.Parameters.AddWithValue("@designation_qualification", model.designation_qualification);
            sqlcmd.Parameters.AddWithValue("@designation_description", model.designation_description);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.Parameters.AddWithValue("@ac_flag", model.ac_flag);

            sqlcmd.ExecuteNonQuery();
        }
        [HttpDelete]
        public ActionResult DeleteData(int Id)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            string qry = "delete from m_designation_information where designation_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_designation_information where designation_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var designation_list = new List<Designation_Information_Model>();

            Designation_Information_Model m = new Designation_Information_Model()
            {
                designation_id = Convert.ToInt32(dt.Rows[0]["designation_id"]),
                designation_name = dt.Rows[0]["designation_name"].ToString(),
                designation_qualification = dt.Rows[0]["designation_qualification"].ToString(),
                designation_description = dt.Rows[0]["designation_description"].ToString(),
                designation_code = dt.Rows[0]["designation_code"].ToString()
            };
            designation_list.Add(m);
            return Ok(designation_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_designation_information where designation_name like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var designation_list = new List<Designation_Information_Model>();

            Designation_Information_Model m = new Designation_Information_Model()
            {
                designation_id = Convert.ToInt32(dt.Rows[0]["designation_id"]),
                designation_name = dt.Rows[0]["designation_name"].ToString(),
                designation_qualification = dt.Rows[0]["designation_qualification"].ToString(),
                designation_description = dt.Rows[0]["designation_description"].ToString(),
                designation_code = dt.Rows[0]["designation_code"].ToString()
            };
            designation_list.Add(m);
            return Ok(designation_list);
        }
    }
}
