using System.ComponentModel.DataAnnotations;

namespace ca3_x00162229.Shared
{
    public class UserInput
    {
        [Required]
        public string? Query { get; set; }
    }
}
