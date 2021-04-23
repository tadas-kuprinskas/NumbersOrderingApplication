using DanskeHomeworkAssignment.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DanskeHomeworkAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortingController : ControllerBase
    {
        private readonly IPerformanceMeasureService _performanceMeasureService;
        private readonly ISortingService _sortingService;

        public SortingController(IPerformanceMeasureService performanceMeasureService,
            ISortingService sortingService)
        {
            _performanceMeasureService = performanceMeasureService;
            _sortingService = sortingService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult SortNumbers(string lineOfNumbers)
        {
            try
            {
                _sortingService.SortInput(lineOfNumbers);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("performance")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        public IActionResult GetPerformanceMeasures()
        {
            try
            {
                return Ok(_performanceMeasureService.ReturnPerformanceResults());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
