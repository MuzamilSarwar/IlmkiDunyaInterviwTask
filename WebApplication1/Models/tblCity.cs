using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class tblCity
    {
        [Key]
        public int City_id { get; set; }
        [MaxLength(25)]
        public string City_name { get; set; } = string.Empty;
    }
}
