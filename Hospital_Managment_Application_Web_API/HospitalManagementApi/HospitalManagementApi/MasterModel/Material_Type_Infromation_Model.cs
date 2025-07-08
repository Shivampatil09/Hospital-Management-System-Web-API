using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _1_Hospital_Managment_Model.MasterModel
{
    public class Material_Type_Infromation_Model
    {
        public int material_type_id { get; set; }
        public string material_type { get; set; }
        public int global_id { get; set; }
        public int created_by { get; set; }
        public DateTime created_date { get; set; }
        public int updated_by { get; set; }
        public DateTime updated_date { get; set; }
        public string flag { get; set; }
    }
}
