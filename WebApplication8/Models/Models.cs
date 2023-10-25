using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class Models
    {
        public class LoginModel
        {
            [Required]
            public string Name { get; set; }
            
            [Required]
            public string Password { get; set; }
        }
        
        public class RegisterModel
        {
            [Required]
            public string Name { get; set; } 
            
            [Required]
            public byte Age { get; set; }
            
            [Required]
            public string Email { get; set; }
            
            [Required]
            public string RegionId { get; set; }
            
            public string Phone { get; set; }
            
            [Required]
            public string Password { get; set; }
        }
    }
}