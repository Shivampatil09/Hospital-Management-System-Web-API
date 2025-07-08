using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Packing : ControllerBase
    {
        [HttpGet]
        public List<Packing_Model> Getdata()
        {
            string qry = "select * from m_packing";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var packingl_list = new List<Packing_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Packing_Model m = new Packing_Model()
                {
                    packing_id = Convert.ToInt32(dt.Rows[i]["packing_id"]),
                    packing_name = dt.Rows[i]["packing_name"].ToString(),
                    first_packing_convert = Convert.ToInt32(dt.Rows[i]["first_packing_convert"]),
                    second_packing_convert = Convert.ToInt32(dt.Rows[i]["second_packing_convert"])
                };
                packingl_list.Add(m);
            }
            return packingl_list;
        }

        [HttpPost]
        public void PostData(Packing_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.packing_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_packing";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@packing_id", model.packing_id);
            sqlcmd.Parameters.AddWithValue("@packing_name", model.packing_name);
            sqlcmd.Parameters.AddWithValue("@first_packing_convert", model.first_packing_convert);
            sqlcmd.Parameters.AddWithValue("@second_packing_convert", model.second_packing_convert);

            sqlcmd.ExecuteNonQuery();
        }
        [HttpDelete]
        public ActionResult DeleteData(int Id)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            string qry = "delete from m_packing where packing_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_packing where packing_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var packingl_list = new List<Packing_Model>();

            Packing_Model m = new Packing_Model()
            {
                packing_id = Convert.ToInt32(dt.Rows[0]["packing_id"]),
                packing_name = dt.Rows[0]["packing_name"].ToString(),
                first_packing_convert = Convert.ToInt32(dt.Rows[0]["first_packing_convert"]),
                second_packing_convert = Convert.ToInt32(dt.Rows[0]["second_packing_convert"])
            };
            packingl_list.Add(m);
            return Ok(packingl_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_packing where packing_name like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var packingl_list = new List<Packing_Model>();

            Packing_Model m = new Packing_Model()
            {
                packing_id = Convert.ToInt32(dt.Rows[0]["packing_id"]),
                packing_name = dt.Rows[0]["packing_name"].ToString(),
                first_packing_convert = Convert.ToInt32(dt.Rows[0]["first_packing_convert"]),
                second_packing_convert = Convert.ToInt32(dt.Rows[0]["second_packing_convert"])
            };
            packingl_list.Add(m);
            return Ok(packingl_list);
        }

    }
}
