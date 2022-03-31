namespace Donations.API.Models.Data
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
    }
}