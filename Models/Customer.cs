using System.ComponentModel.DataAnnotations;

namespace BlazorCrudApp.Models
{
    public class Customer
    {
        [Key]
        public int CusID { get; set; }
        public string CusName { get; set; } = string.Empty;
        public decimal CusBalane { get; set; }
        public string CusType { get; set; } = string.Empty;
        public string CusDescription { get; set; } = string.Empty;
    }
}
