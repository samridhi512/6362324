using System.ComponentModel.DataAnnotations;
namespace EmployeeCrudApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Department { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
        [Required]
        public string HireDate { get; set; } = string.Empty;
    }
    public class EmployeeUpdateRequest
    {
        [StringLength(100)]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? Department { get; set; }
        [Range(0, double.MaxValue)]
        public decimal? Salary { get; set; }
        public string? HireDate { get; set; }
    }
    public class ApiResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public bool Success { get; set; }
    }
    public class ErrorResponse
    {
        public string Error { get; set; } = string.Empty;
    }
}