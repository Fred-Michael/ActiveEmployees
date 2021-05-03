using System;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Models.DTOs
{
    public class EmployeeDTO
    {
        public string EmployeeId { get; set; }
        [StringLength(50, ErrorMessage = "Employee first name is too long")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Employee last name is too long")]
        public string LastName { get; set; }
        [Range(18, 65, ErrorMessage = "Employee age should be between 18 - 65 years old")]
        public string Age { get; set; }
        public DateTime Join_Date { get; set; }
    }
}