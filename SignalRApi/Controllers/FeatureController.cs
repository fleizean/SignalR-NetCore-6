using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            if (createFeatureDto != null)
            {
                _featureService.TAdd(new Feature()
                {
                    Title = createFeatureDto.Title,
                    Description = createFeatureDto.Description,
                    Status = true
                });
                return Ok("Feature added successfuly");
            }
            return NotFound("Feature not added successfuly");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            if (value != null)
            {
                _featureService.TDelete(value);
                return Ok("Feature deleted successfuly");
            }
            return NotFound("Feature not deleted successfuly");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                Title = updateFeatureDto.Title,
                Description = updateFeatureDto.Description,
                Status = updateFeatureDto.Status
            });
            return Ok("Feature updated successfuly");
        }

        [HttpGet("{id}")]
        public IActionResult GetFeatureById(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }
    }
}

