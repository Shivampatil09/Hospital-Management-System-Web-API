using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalInformation : ControllerBase
    {
        [HttpGet]
        public List<Hospital_Information_Model> Getdata()
        {
            string qry = "select * from m_hospital_information";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var hospital_list = new List<Hospital_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Hospital_Information_Model m = new Hospital_Information_Model()
                {
                    hospital_id = Convert.ToInt32(dt.Rows[i]["hospital_id"]),
                    hospital_name = dt.Rows[i]["hospital_name"].ToString(),
                    hospital_address = dt.Rows[i]["hospital_address"].ToString(),
                    hospital_email_address = dt.Rows[i]["hospital_email_address"].ToString(),
                    hospital_city = dt.Rows[i]["hospital_city"].ToString(),
                    hospital_pan = dt.Rows[i]["hospital_pan"].ToString(),
                    hospital_gst_number = dt.Rows[i]["hospital_gst_number"].ToString(),
                    hospital_contact_number = dt.Rows[i]["hospital_contact_number"].ToString(),
                    hospital_contact_number1 = dt.Rows[i]["hospital_contact_number1"].ToString(),
                    hospital_web_site = dt.Rows[i]["hospital_web_site"].ToString()
                };
                hospital_list.Add(m);
            }
            return hospital_list;
        }

        [HttpPost]
        public async void PostData(Hospital_Information_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.hospital_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_hospital_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@hospital_id", model.hospital_id);
            sqlcmd.Parameters.AddWithValue("@hospital_name", model.hospital_name);
            sqlcmd.Parameters.AddWithValue("@hospital_address", model.hospital_address);
            sqlcmd.Parameters.AddWithValue("@hospital_email_address", model.hospital_email_address);
            sqlcmd.Parameters.AddWithValue("@logo", "");
            sqlcmd.Parameters.AddWithValue("@hospital_city", model.hospital_city);
            sqlcmd.Parameters.AddWithValue("@hospital_pan", model.hospital_pan);
            sqlcmd.Parameters.AddWithValue("@hospital_gst_number", model.hospital_gst_number);
            sqlcmd.Parameters.AddWithValue("@hospital_contact_number", model.hospital_contact_number);
            sqlcmd.Parameters.AddWithValue("@hospital_contact_number1", model.hospital_contact_number1);
            sqlcmd.Parameters.AddWithValue("@hospital_web_site", model.hospital_web_site);
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
            string qry = "delete from m_hospital_information where hospital_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_hospital_information where hospital_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var hospital_list = new List<Hospital_Information_Model>();

            Hospital_Information_Model m = new Hospital_Information_Model()
            {
                hospital_id = Convert.ToInt32(dt.Rows[0]["hospital_id"]),
                hospital_name = dt.Rows[0]["hospital_name"].ToString(),
                hospital_address = dt.Rows[0]["hospital_address"].ToString(),
                hospital_email_address = dt.Rows[0]["hospital_email_address"].ToString(),
                hospital_city = dt.Rows[0]["hospital_city"].ToString(),
                hospital_pan = dt.Rows[0]["hospital_pan"].ToString(),
                hospital_gst_number = dt.Rows[0]["hospital_gst_number"].ToString(),
                hospital_contact_number = dt.Rows[0]["hospital_contact_number"].ToString(),
                hospital_contact_number1 = dt.Rows[0]["hospital_contact_number1"].ToString(),
                hospital_web_site = dt.Rows[0]["hospital_web_site"].ToString()
            };
            hospital_list.Add(m);
            return Ok(hospital_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_hospital_information where hospital_name like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var hospital_list = new List<Hospital_Information_Model>();

            Hospital_Information_Model m = new Hospital_Information_Model()
            {
                hospital_id = Convert.ToInt32(dt.Rows[0]["hospital_id"]),
                hospital_name = dt.Rows[0]["hospital_name"].ToString(),
                hospital_address = dt.Rows[0]["hospital_address"].ToString(),
                hospital_email_address = dt.Rows[0]["hospital_email_address"].ToString(),
                hospital_city = dt.Rows[0]["hospital_city"].ToString(),
                hospital_pan = dt.Rows[0]["hospital_pan"].ToString(),
                hospital_gst_number = dt.Rows[0]["hospital_gst_number"].ToString(),
                hospital_contact_number = dt.Rows[0]["hospital_contact_number"].ToString(),
                hospital_contact_number1 = dt.Rows[0]["hospital_contact_number1"].ToString(),
                hospital_web_site = dt.Rows[0]["hospital_web_site"].ToString()
            };
            hospital_list.Add(m);
            return Ok(hospital_list);
        }
    }
}
