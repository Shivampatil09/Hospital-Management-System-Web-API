using _1_Hospital_Managment_Model.MasterModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemInformation : ControllerBase
    {
        [HttpGet]
        public List<Item_Information_Model> Getdata()
        {
            string qry = "select * from m_item_information";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var item_list = new List<Item_Information_Model>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Item_Information_Model m = new Item_Information_Model()
                {
                    item_id = Convert.ToInt32(dt.Rows[i]["item_id"]),
                    item_code = dt.Rows[i]["item_code"].ToString(),
                    item_type = Convert.ToInt32(dt.Rows[i]["item_type"]),
                    item_name = dt.Rows[i]["item_name"].ToString(),
                    item_manufaction_name = dt.Rows[i]["item_manufaction_name"].ToString(),
                    item_pacinking = Convert.ToInt32(dt.Rows[i]["item_pacinking"]),
                    item_use_name = dt.Rows[i]["item_use_name"].ToString(),
                    item_description = dt.Rows[i]["item_description"].ToString(),
                    item_start_date = Convert.ToDateTime(dt.Rows[i]["item_start_date"]),
                    item_end_date = Convert.ToDateTime(dt.Rows[i]["item_start_date"]),
                    item_first_unit = Convert.ToInt32(dt.Rows[i]["item_first_unit"]),
                    item_second_unit = Convert.ToInt32(dt.Rows[i]["item_second_unit"]),
                    item_conversion_first_factor = Convert.ToDecimal(dt.Rows[i]["item_conversion_first_factor"]),
                    item_conversion_second_factor = Convert.ToDecimal(dt.Rows[i]["item_conversion_second_factor"]),
                    item_is_stockebal = Convert.ToInt32(dt.Rows[i]["item_is_stockebal"]),
                    item_quality_check = Convert.ToInt32(dt.Rows[i]["item_quality_check"]),
                    item_return_policy = Convert.ToInt32(dt.Rows[i]["item_return_policy"]),
                    item_min_qty = Convert.ToDecimal(dt.Rows[i]["item_min_qty"]),
                    item_max_qty = Convert.ToDecimal(dt.Rows[i]["item_max_qty"]),
                    item_hsn_code = dt.Rows[i]["item_hsn_code"].ToString(),
                    item_po_type = Convert.ToInt32(dt.Rows[i]["item_po_type"]),
                    item_tax_apply = Convert.ToInt32(dt.Rows[i]["item_tax_apply"]),
                    item_po_tax_group = Convert.ToDecimal(dt.Rows[i]["item_po_tax_group"]),
                    item_sale_tax_group = Convert.ToDecimal(dt.Rows[i]["item_sale_tax_group"])
                };
                item_list.Add(m);
            }
            return item_list;
        }

        [HttpPost]
        public async void PostData(Item_Information_Model model)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            if (model.item_id == 0)
            {

                sqlcmd.Parameters.AddWithValue("@flag", "I");
            }
            else
            {

                sqlcmd.Parameters.AddWithValue("@flag", "U");
            }
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "SP_m_item_information";
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@item_id", model.item_id);
            sqlcmd.Parameters.AddWithValue("@item_code", model.item_code);
            sqlcmd.Parameters.AddWithValue("@item_type", model.item_type);
            sqlcmd.Parameters.AddWithValue("@item_name", model.item_name);
            sqlcmd.Parameters.AddWithValue("@item_manufaction_name", model.item_manufaction_name);
            sqlcmd.Parameters.AddWithValue("@item_pacinking", model.item_pacinking);
            sqlcmd.Parameters.AddWithValue("@item_use_name", model.item_use_name);
            sqlcmd.Parameters.AddWithValue("@item_description", model.item_description);
            sqlcmd.Parameters.AddWithValue("@item_start_date", model.item_start_date);
            sqlcmd.Parameters.AddWithValue("@item_end_date", model.item_end_date);
            sqlcmd.Parameters.AddWithValue("@item_first_unit", model.item_first_unit);
            sqlcmd.Parameters.AddWithValue("@item_second_unit", model.item_second_unit);
            sqlcmd.Parameters.AddWithValue("@item_conversion_first_factor", model.item_conversion_first_factor);
            sqlcmd.Parameters.AddWithValue("@item_conversion_second_factor", model.item_conversion_second_factor);
            sqlcmd.Parameters.AddWithValue("@item_is_stockebal", model.item_is_stockebal);
            sqlcmd.Parameters.AddWithValue("@item_quality_check", model.item_quality_check);
            sqlcmd.Parameters.AddWithValue("@item_return_policy", model.item_return_policy);
            sqlcmd.Parameters.AddWithValue("@item_min_qty", model.item_min_qty);
            sqlcmd.Parameters.AddWithValue("@item_max_qty", model.item_max_qty);
            sqlcmd.Parameters.AddWithValue("@item_hsn_code", model.item_hsn_code);
            sqlcmd.Parameters.AddWithValue("@item_po_type", model.item_po_type);
            sqlcmd.Parameters.AddWithValue("@item_tax_apply", model.item_tax_apply);
            sqlcmd.Parameters.AddWithValue("@item_po_tax_group", model.item_po_tax_group);
            sqlcmd.Parameters.AddWithValue("@item_sale_tax_group", model.item_sale_tax_group);
            sqlcmd.Parameters.AddWithValue("@created_by", model.created_by);
            sqlcmd.Parameters.AddWithValue("@updated_by", model.updated_by);
            sqlcmd.Parameters.AddWithValue("@activ_flag", model.activ_flag);

            sqlcmd.ExecuteNonQuery();
        }
        [HttpDelete]
        public ActionResult DeleteData(int Id)
        {
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            string qry = "delete from m_item_information where item_id=" + Id;
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            sqlcmd.ExecuteNonQuery();
            return Ok();
        }
        [HttpGet]
        [Route("GetByID")]
        public IActionResult GetByID(int Id)
        {
            string qry = "select * from m_item_information where item_id=" + Id;
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var item_list = new List<Item_Information_Model>();

            Item_Information_Model m = new Item_Information_Model()
            {
                item_id = Convert.ToInt32(dt.Rows[0]["item_id"]),
                item_code = dt.Rows[0]["item_code"].ToString(),
                item_type = Convert.ToInt32(dt.Rows[0]["item_type"]),
                item_name = dt.Rows[0]["item_name"].ToString(),
                item_manufaction_name = dt.Rows[0]["item_manufaction_name"].ToString(),
                item_pacinking = Convert.ToInt32(dt.Rows[0]["item_pacinking"]),
                item_use_name = dt.Rows[0]["item_use_name"].ToString(),
                item_description = dt.Rows[0]["item_description"].ToString(),
                item_start_date = Convert.ToDateTime(dt.Rows[0]["item_start_date"]),
                item_end_date = Convert.ToDateTime(dt.Rows[0]["item_start_date"]),
                item_first_unit = Convert.ToInt32(dt.Rows[0]["item_first_unit"]),
                item_second_unit = Convert.ToInt32(dt.Rows[0]["item_second_unit"]),
                item_conversion_first_factor = Convert.ToDecimal(dt.Rows[0]["item_conversion_first_factor"]),
                item_conversion_second_factor = Convert.ToDecimal(dt.Rows[0]["item_conversion_second_factor"]),
                item_is_stockebal = Convert.ToInt32(dt.Rows[0]["item_is_stockebal"]),
                item_quality_check = Convert.ToInt32(dt.Rows[0]["item_quality_check"]),
                item_return_policy = Convert.ToInt32(dt.Rows[0]["item_return_policy"]),
                item_min_qty = Convert.ToDecimal(dt.Rows[0]["item_min_qty"]),
                item_max_qty = Convert.ToDecimal(dt.Rows[0]["item_max_qty"]),
                item_hsn_code = dt.Rows[0]["item_hsn_code"].ToString(),
                item_po_type = Convert.ToInt32(dt.Rows[0]["item_po_type"]),
                item_tax_apply = Convert.ToInt32(dt.Rows[0]["item_tax_apply"]),
                item_po_tax_group = Convert.ToDecimal(dt.Rows[0]["item_po_tax_group"]),
                item_sale_tax_group = Convert.ToDecimal(dt.Rows[0]["item_sale_tax_group"])
            };
            item_list.Add(m);
            return Ok(item_list);
        }
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string name)
        {
            string qry = "select * from m_item_information where item_name like '" + name + "%'";
            string Constr = "data source=UNKNOWN\\SQLEXPRESS;initial catalog=Db_Hospital_Managment;user id=sa;password=Game@123;trustservercertificate=True;";
            SqlConnection sqlcon = new SqlConnection(Constr);
            sqlcon.Close();
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand(qry, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var item_list = new List<Item_Information_Model>();

            Item_Information_Model m = new Item_Information_Model()
            {
                item_id = Convert.ToInt32(dt.Rows[0]["item_id"]),
                item_code = dt.Rows[0]["item_code"].ToString(),
                item_type = Convert.ToInt32(dt.Rows[0]["item_type"]),
                item_name = dt.Rows[0]["item_name"].ToString(),
                item_manufaction_name = dt.Rows[0]["item_manufaction_name"].ToString(),
                item_pacinking = Convert.ToInt32(dt.Rows[0]["item_pacinking"]),
                item_use_name = dt.Rows[0]["item_use_name"].ToString(),
                item_description = dt.Rows[0]["item_description"].ToString(),
                item_start_date = Convert.ToDateTime(dt.Rows[0]["item_start_date"]),
                item_end_date = Convert.ToDateTime(dt.Rows[0]["item_start_date"]),
                item_first_unit = Convert.ToInt32(dt.Rows[0]["item_first_unit"]),
                item_second_unit = Convert.ToInt32(dt.Rows[0]["item_second_unit"]),
                item_conversion_first_factor = Convert.ToDecimal(dt.Rows[0]["item_conversion_first_factor"]),
                item_conversion_second_factor = Convert.ToDecimal(dt.Rows[0]["item_conversion_second_factor"]),
                item_is_stockebal = Convert.ToInt32(dt.Rows[0]["item_is_stockebal"]),
                item_quality_check = Convert.ToInt32(dt.Rows[0]["item_quality_check"]),
                item_return_policy = Convert.ToInt32(dt.Rows[0]["item_return_policy"]),
                item_min_qty = Convert.ToDecimal(dt.Rows[0]["item_min_qty"]),
                item_max_qty = Convert.ToDecimal(dt.Rows[0]["item_max_qty"]),
                item_hsn_code = dt.Rows[0]["item_hsn_code"].ToString(),
                item_po_type = Convert.ToInt32(dt.Rows[0]["item_po_type"]),
                item_tax_apply = Convert.ToInt32(dt.Rows[0]["item_tax_apply"]),
                item_po_tax_group = Convert.ToDecimal(dt.Rows[0]["item_po_tax_group"]),
                item_sale_tax_group = Convert.ToDecimal(dt.Rows[0]["item_sale_tax_group"])
            };
            item_list.Add(m);
            return Ok(item_list);
        }
    }
}
