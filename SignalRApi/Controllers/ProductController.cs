using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var productsWithCategories = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(productsWithCategories);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var values = _productService.TProductCount();
            return Ok(values);
        }

        [HttpGet("ProductAveragePrice")]
        public IActionResult ProductAveragePrice()
        {
            var values = _productService.TProductPriceAverage();
            return Ok(values);
        }

        [HttpGet("HighestProductPriceName")]
        public IActionResult HighestProductPriceName()
        {
            var values = _productService.THighestProductPriceName();
            return Ok(values);
        }

        [HttpGet("LowestProductPriceName")]
        public IActionResult LowestProductPriceName()
        {
            var values = _productService.TLowestProductPriceName();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            if (createProductDto != null)
            {
                _productService.TAdd(new Product()
                {
                    ProductName = createProductDto.ProductName,
                    Description = createProductDto.Description,
                    Price = createProductDto.Price,
                    ImageUrl = createProductDto.ImageUrl,
                    CategoryID = createProductDto.categoryID,
                    Status = true
                });
                return Ok("Product added successfuly");
            }
            return NotFound("Product not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            if (value != null)
            {
                _productService.TDelete(value);
                return Ok("Product deleted successfuly");
            }
            return NotFound("Product not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                ProductID = updateProductDto.ProductID,
                ProductName = updateProductDto.ProductName,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                ImageUrl = updateProductDto.ImageUrl,
                Status = updateProductDto.Status,
                CategoryID = updateProductDto.categoryID
            });
            return Ok("Product updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }
}

