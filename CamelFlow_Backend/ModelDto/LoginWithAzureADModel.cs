using System.ComponentModel.DataAnnotations;

namespace CamelFlow_Backend.ModelDto
{
    public class LoginWithAzureADModel
    {
        [Required]
        public string IDToken { get; set; } = string.Empty;
    }
}
