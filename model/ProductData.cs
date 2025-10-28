using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.model
{
    public class ProductData
    {
        [Key]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "O Campo de Nome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O Campo ter no máximo 50 caracteres!")]
        [MinLength(3, ErrorMessage = "O Campo ter no mínimo 3 caracteres!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O Campo de Marca é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O Campo ter no máximo 50 caracteres!")]
        [MinLength(3, ErrorMessage = "O Campo ter no mínimo 3 caracteres!")]
        public string Marker { get; set; }
        [Required(ErrorMessage = "O Campo de Categoria é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O Campo ter no máximo 50 caracteres!")]
        [MinLength(3, ErrorMessage = "O Campo ter no mínimo 3 caracteres!")]
        public string Category { get; set; }
        [Required(ErrorMessage = "O Campo de Descrição é obrigatório!")]
        [MaxLength(500, ErrorMessage = "O Campo ter no máximo 500 caracteres!")]
        [MinLength(50, ErrorMessage = "O Campo ter no mínimo 50 caracteres!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O Campo de Preço é obrigatório!")]
        public decimal PriceProduct { get; set; }
        public string ImageMain { get; set; }
        public string ImagePrimary { get; set; }
        public string ImageSecondary { get; set; }
        public string ImageTertiary { get; set; }
        public string ImageQuaternary { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal? OfferPrice { get; set; }
    }
}