using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SE162152.ProductManagement.API.Contracts.Requests
{
    public class CreateCategoryRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [StringLength(40)]
        public string CategoryName { get; set; }
    }
}
