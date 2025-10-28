using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.model;
using BackEnd.data;


namespace BackEnd.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterProductController : ControllerBase
    {
        private readonly AppDbContext _DbContext;

        public RegisterProductController(AppDbContext context)
        {
            _DbContext = context;
        }

        [HttpPost("RegisterProduct")]

        public async Task<IActionResult> RegisterProduct([FromBody] ProductData productData)
        {
            try
            {
                var checkProduct = await _DbContext.ProductDatas.FirstOrDefaultAsync(x => x.Name == productData.Name);
                if (checkProduct != null)
                {
                    return Conflict("Produto ja cadastrado");
                }

                var product = new ProductData()
                {
                    Name = productData.Name,
                    Marker = productData.Marker,
                    Category = productData.Category,
                    PriceProduct = productData.PriceProduct,
                    Description = productData.Description,
                    ImageMain = productData.ImageMain,
                    ImagePrimary = productData.ImagePrimary,
                    ImageSecondary = productData.ImageSecondary,
                    ImageTertiary = productData.ImageTertiary,
                    ImageQuaternary = productData.ImageQuaternary,
                    DateStart = productData.DateStart,
                    DateEnd = productData.DateEnd,
                    OfferPrice = productData.OfferPrice
                };
                _DbContext.ProductDatas.Add(product);
                await _DbContext.SaveChangesAsync();
                return Ok("O Produto foi Cadastrado com Sucesso");

            }
            catch
            {
                return BadRequest("Ouve um erro ao cadastrar o produto Inesperado Tente Novamente Mais Tarde");
            }
        }

    }
}