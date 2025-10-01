using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace BackEnd.model
{
    public class Login
    {
        [Key]
        public int idUser { get; set; }
        [Required]
        [JsonPropertyName("email")]
        public string email { get; set; }
        [MinLength(3)]
        [JsonPropertyName("nameUser")]
        public string nameUser { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(12)]
        [JsonPropertyName("password")]  
        public string password { get; set; }
    }
}