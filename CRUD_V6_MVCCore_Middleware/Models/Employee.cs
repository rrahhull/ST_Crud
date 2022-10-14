﻿using System.ComponentModel.DataAnnotations;

namespace CRUD_V6_MVCCore_Middleware.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Employee Name")]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public DateTime? RecordCreatedOn { get; set; }
    }
}
