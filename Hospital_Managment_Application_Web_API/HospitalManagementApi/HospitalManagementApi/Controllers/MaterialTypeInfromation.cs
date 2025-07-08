using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypeInfromation : ControllerBase
    {
        [HttpGet]
        public List<Material_Type_Infromation_Model> Getdata()
        {
            string qry = "select * from m_material_type_infromation";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var material_list = new List<Material_Type_Infromation_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Material_Type_Infromation_Model m = new Material_Type_Infromation_Model()
                {
                    material_type_id = Convert.ToInt32(dt.Rows[i]["material_type_id"]),
                    material_type = dt.Rows[i]["material_type"].ToString(),
                    global_id = Convert.ToInt32(dt.Rows[i]["global_id"])
                };
                material_list.Add(m);
            }
            return material_list;
        }

        [HttpPost]
        public async void PostData(Material_Type_Infromation_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.material_type_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_material_type_infromation";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@material_type_id", model.material_type_id);
            sqlcmd.Parameters.AddWithValue("@material_type", model.material_type);
            sqlcmd.Parameters.AddWithValue("@global_id", model.global_id);
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
            string qry = "delete from m_material_type_infromation where material_type_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_material_type_infromation where material_type_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var material_list = new List<Material_Type_Infromation_Model>();

            Material_Type_Infromation_Model m = new Material_Type_Infromation_Model()
            {
                material_type_id = Convert.ToInt32(dt.Rows[0]["material_type_id"]),
                material_type = dt.Rows[0]["material_type"].ToString(),
                global_id = Convert.ToInt32(dt.Rows[0]["global_id"])
            };
            material_list.Add(m);
            return Ok(material_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_material_type_infromation where material_type like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var material_list = new List<Material_Type_Infromation_Model>();

            Material_Type_Infromation_Model m = new Material_Type_Infromation_Model()
            {
                material_type_id = Convert.ToInt32(dt.Rows[0]["material_type_id"]),
                material_type = dt.Rows[0]["material_type"].ToString(),
                global_id = Convert.ToInt32(dt.Rows[0]["global_id"])
            };
            material_list.Add(m);
            return Ok(material_list);
        }
    }
}
