using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services.MeasurementService.Abstract;
using WebAPI.Services.MeasurementService.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : Controller
    {
        #region Dependency Injection
        private readonly IMeasurementService _measurementService;
        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }
        #endregion Dependency Injection

        // GET: api/<ItemController>
        [HttpGet]
        public async Task<ActionResult<MeasurementDto>> Get()
        {
            return Ok(await _measurementService.GetMeasurementAsync());
        }

        // GET api/<ItemController>/5
        [HttpGet("{timeFrame}", Name = "Get")]
        public async Task<ActionResult<IEnumerable<MeasurementDto>>> Get(TimeFrame timeFrame)
        {
            //if (timeFrame == null)
            //{
            //    return NotFound();
            //}
            return Ok(await _measurementService.GetMeasurementsAsync(timeFrame));
        }
    }
}
