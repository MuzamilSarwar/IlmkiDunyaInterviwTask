using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace WebApplication1.Models
{
    public class tblCustomers
    {
        [Key]
        public int Customer_id { get; set; }
        [MaxLength(25)]
        [Display(Name ="Customer Name")]
        [Required]
        public string Customer_name { get; set; } = string.Empty;
        [Display(Name = "Gender")]
        [Required]
        public bool gender { get; set; } 
        public string details { get; set; } = string.Empty;
        [Display(Name = "Dated")]
        public DateTime Dated { get; set; }
        [Display(Name ="City")]
        [Required]
        public int City_id { get; set; }
        [ForeignKey("City_id")]
        public tblCity? tblCity { get; set; }
    }
}
