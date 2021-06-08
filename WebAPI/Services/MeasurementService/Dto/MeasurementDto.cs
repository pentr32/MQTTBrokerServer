using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.MeasurementService.Dto
{
    public class MeasurementDto
    {
        public DateTime TimeCreated { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
    }
}
