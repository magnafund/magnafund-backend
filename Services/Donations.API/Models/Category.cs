using System.ComponentModel.DataAnnotations;

namespace Donations.API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}