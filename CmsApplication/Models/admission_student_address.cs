//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CmsApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class admission_student_address
    {
        public admission_student_address()
        {
            this.admission_form = new HashSet<admission_form>();
        }
    
        public int student_address_id { get; set; }
        public int admission_student_id { get; set; }
        public string parmanent_village { get; set; }
        public string parmanent_post { get; set; }
        public string parmanent_post_code { get; set; }
        public int parmanent_sub_district_id { get; set; }
        public int present_sub_district_id { get; set; }
        public string present_village { get; set; }
        public string present_post { get; set; }
        public string present_post_code { get; set; }
        public string mobile_number { get; set; }
    
        public virtual ICollection<admission_form> admission_form { get; set; }
        public virtual sub_district sub_district { get; set; }
        public virtual sub_district sub_district1 { get; set; }
    }
}
