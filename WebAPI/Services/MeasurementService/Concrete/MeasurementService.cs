using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services.MeasurementService.Abstract;
using WebAPI.Services.MeasurementService.Dto;

namespace WebAPI.Services.MeasurementService.Concrete
{
    public class MeasurementService : IMeasurementService
    {
        #region Dependency Injection
        private readonly MeasurementsContext _context;
        public MeasurementService(MeasurementsContext context)
        {
            _context = context;
        }
        #endregion Dependency Injection


        public async Task<MeasurementDto> GetMeasurementAsync()
        {
            return await Task.FromResult(_context.Measurements
                .Select(a => new MeasurementDto {
                    Temperature = a.Temperature,
                    Humidity = a.Humidity,
                    TimeCreated = a.TimeCreated
            }).OrderByDescending(g => g.TimeCreated).FirstOrDefault());
        }

        public async Task<IEnumerable<MeasurementDto>> GetMeasurementsAsync(TimeFrame timeFrame, bool forceRefresh = false)
        {
            switch (timeFrame)
            {
                case TimeFrame.LatestHour:
                    return await Task.FromResult(_context.Measurements.Take(5)
                        .Select(a => new MeasurementDto
                        {
                            Temperature = a.Temperature,
                            Humidity = a.Humidity,
                            TimeCreated = a.TimeCreated
                        }).OrderBy(m => m.TimeCreated));

                case TimeFrame.LatestDay:
                    return await Task.FromResult(_context.Measurements.Take(10)
                        .Select(a => new MeasurementDto
                        {
                            Temperature = a.Temperature,
                            Humidity = a.Humidity,
                            TimeCreated = a.TimeCreated
                        }).OrderBy(m => m.TimeCreated));

                case TimeFrame.LatestWeek:
                    return await Task.FromResult(_context.Measurements.Take(15)
                        .Select(a => new MeasurementDto
                        {
                            Temperature = a.Temperature,
                            Humidity = a.Humidity,
                            TimeCreated = a.TimeCreated
                        }).OrderBy(m => m.TimeCreated));

                default:
                    return await Task.FromResult(_context.Measurements
                        .Select(a => new MeasurementDto
                        {
                            Temperature = a.Temperature,
                            Humidity = a.Humidity,
                            TimeCreated = a.TimeCreated
                        }).OrderBy(m => m.TimeCreated));
            }
        }
    }
}
