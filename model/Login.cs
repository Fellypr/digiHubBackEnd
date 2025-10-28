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
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email é inválido")]
        [MinLength(3)]
        [JsonPropertyName("email")]
        public string email { get; set; }
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres")]
        [JsonPropertyName("nameUser")]
        public string nameUser { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "A senha deve ter no mínimo 3 caracteres")]
        [JsonPropertyName("password")]  
        public string password { get; set; }
    }
}