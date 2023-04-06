using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTours.DTOs;
using WebApiTours.Entity;

namespace WebApiTours.Controllers
{
    [Route("api/Detail")]
    [ApiController]
    public class Detailcontroller : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Detailcontroller(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<DetailDTO>>> Get(int tourId)
        {
            var detail = await context.Details.
                Where(detailBD => detailBD.TourId == tourId).ToListAsync(); 

            return mapper.Map<List<DetailDTO>>(detail);

        }


        [HttpPost]

        public async Task<ActionResult> Post(int tourId, DetailCreationDTO detailCreationDTO)
        {
            var existTours = await context.Tours.AnyAsync(tourBD => tourBD.Id == tourId);

            if (!existTours)
            {
                return NotFound();
            }

            var detail = mapper.Map<Detail>(detailCreationDTO);
            detail.TourId = tourId;
            context.Add(detail);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
