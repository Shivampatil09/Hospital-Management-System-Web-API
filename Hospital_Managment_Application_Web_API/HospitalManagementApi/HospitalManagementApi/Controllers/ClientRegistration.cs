using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using _1_Hospital_Managment_Model.MasterModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientRegistration : ControllerBase
    {
        [HttpGet]
        public List<Client_Registration_Model> Getdata()
        {
            string qry = "select * from m_client_registration";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var client_list = new List<Client_Registration_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Client_Registration_Model m = new Client_Registration_Model()
                {
                    client_id = Convert.ToInt32(dt.Rows[i]["client_id"]),
                    client_code = dt.Rows[i]["client_code"].ToString(),
                    client_name = dt.Rows[i]["client_name"].ToString(),
                    busniess_name = dt.Rows[i]["busniess_name"].ToString(),
                    client_city = dt.Rows[i]["client_city"].ToString(),
                    client_phone = dt.Rows[i]["client_phone"].ToString(),
                    client_email = dt.Rows[i]["client_email"].ToString(),
                    client_gst = dt.Rows[i]["client_gst"].ToString(),
                    client_registration_no = dt.Rows[i]["client_registration_no"].ToString(),
                    client_pan = dt.Rows[i]["client_pan"].ToString(),
                    user_name = dt.Rows[i]["user_name"].ToString(),
                    password = dt.Rows[i]["password"].ToString(),
                    client_address = dt.Rows[i]["client_address"].ToString()
                };
                client_list.Add(m);
            }
            return client_list;
        }
        [HttpPost]
        public async void PostData(Client_Registration_Model model)
         {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.client_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_client_registration";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

            sqlcmd.Parameters.AddWithValue("@client_id", model.client_id);
            sqlcmd.Parameters.AddWithValue("@client_code", model.client_code);
            sqlcmd.Parameters.AddWithValue("@client_global_id", model.client_global_id);
            sqlcmd.Parameters.AddWithValue("@client_name", model.client_name);
            sqlcmd.Parameters.AddWithValue("@client_address", model.client_address);
            sqlcmd.Parameters.AddWithValue("@client_phone", model.client_phone);
            sqlcmd.Parameters.AddWithValue("@client_city", model.client_city);
            sqlcmd.Parameters.AddWithValue("@busniess_name", model.busniess_name);
            sqlcmd.Parameters.AddWithValue("@client_pan", model.client_pan);
            sqlcmd.Parameters.AddWithValue("@client_registration_no", model.client_registration_no);
            sqlcmd.Parameters.AddWithValue("@client_gst", model.client_gst);
            sqlcmd.Parameters.AddWithValue("@client_logo", "");
            sqlcmd.Parameters.AddWithValue("@client_email", model.client_email);
            sqlcmd.Parameters.AddWithValue("@password", model.password);
            sqlcmd.Parameters.AddWithValue("@user_name", model.user_name);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@active_flag", "Y");

            sqlcmd.ExecuteNonQuery();
        }
        [HttpDelete]
        public ActionResult DeleteData(int Id)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            string qry = "delete from m_client_registration where client_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_client_registration where client_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var client_list = new List<Client_Registration_Model>();

                Client_Registration_Model m = new Client_Registration_Model()
                {
                    client_id = Convert.ToInt32(dt.Rows[0]["client_id"]),
                    client_code = dt.Rows[0]["client_code"].ToString(),
                    client_name = dt.Rows[0]["client_name"].ToString(),
                    busniess_name = dt.Rows[0]["busniess_name"].ToString(),
                    client_city = dt.Rows[0]["client_city"].ToString(),
                    client_phone = dt.Rows[0]["client_phone"].ToString(),
                    client_email = dt.Rows[0]["client_email"].ToString(),
                    client_gst = dt.Rows[0]["client_gst"].ToString(),
                    client_registration_no = dt.Rows[0]["client_registration_no"].ToString(),
                    client_pan = dt.Rows[0]["client_pan"].ToString(),
                    user_name = dt.Rows[0]["user_name"].ToString(),
                    password = dt.Rows[0]["password"].ToString(),
                    client_address = dt.Rows[0]["client_address"].ToString()
                };
                client_list.Add(m);
            return Ok(client_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_client_registration where client_name like '"+name+"%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var client_list = new List<Client_Registration_Model>();
            Client_Registration_Model m = new Client_Registration_Model()
            {
                client_id = Convert.ToInt32(dt.Rows[0]["client_id"]),
                client_code = dt.Rows[0]["client_code"].ToString(),
                client_name = dt.Rows[0]["client_name"].ToString(),
                busniess_name = dt.Rows[0]["busniess_name"].ToString(),
                client_city = dt.Rows[0]["client_city"].ToString(),
                client_phone = dt.Rows[0]["client_phone"].ToString(),
                client_email = dt.Rows[0]["client_email"].ToString(),
                client_gst = dt.Rows[0]["client_gst"].ToString(),
                client_registration_no = dt.Rows[0]["client_registration_no"].ToString(),
                client_pan = dt.Rows[0]["client_pan"].ToString(),
                user_name = dt.Rows[0]["user_name"].ToString(),
                password = dt.Rows[0]["password"].ToString(),
                client_address = dt.Rows[0]["client_address"].ToString()
            };
            client_list.Add(m);
            return Ok(client_list);
        }
    }
}
