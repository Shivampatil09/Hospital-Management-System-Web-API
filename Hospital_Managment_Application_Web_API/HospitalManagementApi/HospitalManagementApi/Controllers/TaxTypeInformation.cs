using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxTypeInformation : ControllerBase
    {
        [HttpGet]
        public List<Tax_Type_Information_Model> Getdata()
        {
            string qry = "select * from m_tax_type_information";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var tax_type_list = new List<Tax_Type_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Tax_Type_Information_Model m = new Tax_Type_Information_Model()
                {
                    tax_id = Convert.ToInt32(dt.Rows[i]["tax_id"]),
                    tax_name = dt.Rows[i]["tax_name"].ToString(),
                    tax_percent = Convert.ToDecimal(dt.Rows[i]["tax_percent"]),
                    tax_group_id = Convert.ToInt32(dt.Rows[i]["tax_group_id"])
                };
                tax_type_list.Add(m);
            }
            return tax_type_list;
        }


        [HttpPost]
        public void PostData(Tax_Type_Information_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.tax_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_tax_type_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@tax_id", model.tax_id);
            sqlcmd.Parameters.AddWithValue("@tax_name", model.tax_name);
            sqlcmd.Parameters.AddWithValue("@tax_percent", model.tax_percent);
            sqlcmd.Parameters.AddWithValue("@tax_group_id", model.tax_group_id);

            sqlcmd.ExecuteNonQuery();
        }
        [HttpDelete]
        public ActionResult DeleteData(int Id)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            string qry = "delete from m_tax_type_information where tax_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_tax_type_information where tax_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var tax_type_list = new List<Tax_Type_Information_Model>();

            Tax_Type_Information_Model m = new Tax_Type_Information_Model()
            {
                tax_id = Convert.ToInt32(dt.Rows[0]["tax_id"]),
                tax_name = dt.Rows[0]["tax_name"].ToString(),
                tax_percent = Convert.ToDecimal(dt.Rows[0]["tax_percent"]),
                tax_group_id = Convert.ToInt32(dt.Rows[0]["tax_group_id"])
            };
            tax_type_list.Add(m);
            return Ok(tax_type_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_tax_type_information where tax_name like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var tax_type_list = new List<Tax_Type_Information_Model>();

            Tax_Type_Information_Model m = new Tax_Type_Information_Model()
            {
                tax_id = Convert.ToInt32(dt.Rows[0]["tax_id"]),
                tax_name = dt.Rows[0]["tax_name"].ToString(),
                tax_percent = Convert.ToDecimal(dt.Rows[0]["tax_percent"]),
                tax_group_id = Convert.ToInt32(dt.Rows[0]["tax_group_id"])
            };
            tax_type_list.Add(m);
            return Ok(tax_type_list);
        }
    }
}
