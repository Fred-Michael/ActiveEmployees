using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Models.DTOs
{
    public class FindEmployeeDTO
    {
        [Required(ErrorMessage = "You must supply an employee id")]
        public string EmployeeId { get; set; }
    }
}