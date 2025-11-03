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
    public class ManageProductController : ControllerBase
    {
        private readonly AppDbContext _DbContext;

        public ManageProductController(AppDbContext context)
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
        [HttpPost("searchProduct")]

        public async Task<IActionResult> SearchProduct([FromBody] SearchData productData)
        {
            if (string.IsNullOrWhiteSpace(productData?.Name))
            {
                return BadRequest("Preencha todos os Campos");
            }
            var term = productData.Name;
            try
            {
                var foundProduct = await _DbContext.ProductDatas.AsNoTracking().Where(x => x.Name.Contains(term)).ToListAsync();

                if (!foundProduct.Any())
                {
                    return NotFound("Produto Não Encontrado");
                }

                return Ok(foundProduct);
            }
            catch
            {
                return StatusCode(500, "Ouve um erro ao procurar o produto Inesperado Tente Novamente Mais Tarde");
            }

        }
        [HttpPut("UpdateProduct/{id}")]

        public async Task<IActionResult> EditProduct(int id, [FromBody] ProductEditing productData)
        {
            var productChanged = await _DbContext.ProductDatas.FindAsync(id);

            if (productChanged == null)
            {
                return NotFound("Produto Nao Encontrado");
            }
            productChanged.Name = productData.Name;
            productChanged.Marker = productData.Marker;
            productChanged.Category = productData.Category;
            productChanged.PriceProduct = productData.PriceProduct;
            productChanged.Description = productData.Description;
            productChanged.DateStart = productData.DateStart;
            productChanged.DateEnd = productData.DateEnd;
            productChanged.OfferPrice = productData.OfferPrice;
            try
            {
                await _DbContext.SaveChangesAsync();
                return Ok("Produto Alterado com sucesso");
            }
            catch
            {
                return StatusCode(500, "Ouve um erro ao alterar o produto Inesperado Tente Novamente Mais Tarde");
            }
        } 

    }
}