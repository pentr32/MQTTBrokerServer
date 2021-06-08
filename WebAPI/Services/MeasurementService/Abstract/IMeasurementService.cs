using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services.MeasurementService.Dto;

namespace WebAPI.Services.MeasurementService.Abstract
{
    public interface IMeasurementService
    {
        Task<MeasurementDto> GetMeasurementAsync();
        Task<IEnumerable<MeasurementDto>> GetMeasurementsAsync(TimeFrame timeFrame, bool forceRefresh = false);
    }
}
