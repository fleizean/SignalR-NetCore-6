using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var values = _categoryService.TCategoryCount();
            return Ok(values);
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var values = _categoryService.TActiveCategoryCount();
            return Ok(values);
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var values = _categoryService.TPassiveCategoryCount();
            return Ok(values);
        }

        [HttpGet("LatestCategory")]
        public IActionResult LatestCategory()
        {
            var values = _categoryService.TLatestCategory();
            return Ok(values);
        }

        [HttpGet("MostValuableCategory")]
        public IActionResult MostValuableCategory()
        {
            var values = _categoryService.TMostValuableCategory();
            return Ok(values);
        }

        [HttpGet("AtLeastValuableCategory")]
        public IActionResult AtLeastValuableCategory()
        {
            var values = _categoryService.TAtLeastValuableCategory();
            return Ok(values);
        }

        [HttpGet("ZeroProductCategoryCount")]
        public IActionResult ZeroProductCategoryCount()
        {
            var values = _categoryService.TZeroProductCategoryCount();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto != null)
            {
                _categoryService.TAdd(new Category()
                {
                    CategoryName = createCategoryDto.CategoryName,
                    Status = true
                });
                return Ok("Category added successfuly");
            }
            return NotFound("Category not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value != null)
            {
                _categoryService.TDelete(value);
                return Ok("Category deleted successfuly");
            }
            return NotFound("Category not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryID = updateCategoryDto.CategoryID,
                CategoryName = updateCategoryDto.CategoryName,
                Status = updateCategoryDto.Status
            });
            return Ok("Category updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
    }
}

