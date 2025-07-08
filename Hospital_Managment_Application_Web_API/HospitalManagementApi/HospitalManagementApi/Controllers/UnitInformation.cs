using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitInformation : ControllerBase
    {
        [HttpGet]
        public List<Unit_Information_Model> Getdata()
        {
            string qry = "select * from m_unit_information";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var unitInfo_list = new List<Unit_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Unit_Information_Model m = new Unit_Information_Model()
                {
                    unit_id = Convert.ToInt32(dt.Rows[i]["unit_id"]),
                    Unit_name = dt.Rows[i]["Unit_name"].ToString()
                };
                unitInfo_list.Add(m);
            }
            return unitInfo_list;
        }


        [HttpPost]
        public void PostData(Unit_Information_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.unit_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_unit_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@unit_id", model.unit_id);
            sqlcmd.Parameters.AddWithValue("@Unit_name", model.Unit_name);
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
            string qry = "delete from m_unit_information where unit_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_unit_information where unit_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var unitInfo_list = new List<Unit_Information_Model>();

            Unit_Information_Model m = new Unit_Information_Model()
            {
                unit_id = Convert.ToInt32(dt.Rows[0]["unit_id"]),
                Unit_name = dt.Rows[0]["Unit_name"].ToString()
            };
            unitInfo_list.Add(m);
            return Ok(unitInfo_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_unit_information where Unit_name like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var unitInfo_list = new List<Unit_Information_Model>();

            Unit_Information_Model m = new Unit_Information_Model()
            {
                unit_id = Convert.ToInt32(dt.Rows[0]["unit_id"]),
                Unit_name = dt.Rows[0]["Unit_name"].ToString()
            };
            unitInfo_list.Add(m);
            return Ok(unitInfo_list);
        }
    }
}
