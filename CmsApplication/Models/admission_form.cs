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
    
    public partial class admission_form
    {
        public int admission_student_id { get; set; }
        public string student_full_name { get; set; }
        public string student_father_name { get; set; }
        public string student_mother_name { get; set; }
        public int student_address_id { get; set; }
        public string father_education { get; set; }
        public string mohter_education { get; set; }
        public string father_profession { get; set; }
        public string student_refarence { get; set; }
        public System.DateTime student_dob { get; set; }
        public string student_blood_group { get; set; }
        public string student_nationality { get; set; }
        public int student_religion_id { get; set; }
        public string student_exam_name { get; set; }
        public int student_department_id { get; set; }
        public double student_result { get; set; }
        public System.DateTime student_passing_year { get; set; }
        public string student_school_name { get; set; }
        public long student_father_yearly_income { get; set; }
        public string student_email { get; set; }
        public System.DateTime student_apply_date { get; set; }
        public string student_image { get; set; }
        public string student_ssc_roll { get; set; }
        public string student_ssc_registration_no { get; set; }
        public bool student_admission_result { get; set; }
        public string student_admission_password { get; set; }
    
        public virtual admission_student_address admission_student_address { get; set; }
        public virtual student_religion student_religion { get; set; }
    }
}
