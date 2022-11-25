using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper Mapper;
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            //var regions = new List<Region>()
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Wellington",
            //        Code = "WLG",
            //        Area = 227755,
            //        Lat = 1.8822,
            //        Long = 299.88,
            //        Population = 50000000
            //    },
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Auckland",
            //        Code = "AUCK",
            //        Area = 227755,
            //        Lat = 1.8822,
            //        Long = 299.88,
            //        Population = 50000000
            //    }
            //};

            var regions = await regionRepository.GetAllAsync();
            ////Rerunt DTO Region
            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population
            //    };
            //    RegionsDTO.Add(regionDTO);
            //});
            ////En mi caso yo prefiero hacer un Linq
            //var regionsDTO1 = (from region in regions.ToList()
            //                   select new Models.DTO.Region
            //                   {
            //                       Id = region.Id,
            //                       Code = region.Code,
            //                       Name = region.Name,
            //                       Area = region.Area,
            //                       Lat = region.Lat,
            //                       Long = region.Long,
            //                       Population = region.Population
            //                   }).ToList();

            var regionsDTO = Mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }
    }
}
