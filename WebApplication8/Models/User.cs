using System.Collections.Generic;

namespace WebApplication8.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public byte Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        
        public int? RegionId { get; set; }
        public Region Region { get; set; }
    }
    
    public class Region
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}