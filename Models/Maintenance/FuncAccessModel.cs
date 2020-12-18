using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FuncAccessModel : CreatedModified
    {
        public string _id { get; set; }
        public string usergroup_id { get; set; }
        public string functionality_code { get; set; }
        public string functionality_name { get; set; }
        public bool has_access { get; set; }
    }

    public class FuncAccessViewModel
    {
        public FuncAccessViewModel()
        {
            functionality = new List<FunctionalitiesAccessModel>();
        }
        public string _id { get; set; }
        public string usergroup_code { get; set; }
        public List<FunctionalitiesAccessModel> functionality { get; set; }
    }

    public class FunctionalitiesAccessModel
    {
        public string functionality_code { get; set; }
        public string functionality_name { get; set; }
        public bool has_access { get; set; }
    }
}
 