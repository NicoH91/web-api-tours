using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using WebApiTours.DTOs;
using WebApiTours.Entity;

namespace WebApiTours.Controllers
{
    [Route("api/Tour")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TourController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]

        public async Task<ActionResult<List<TourDTO>>> Get()
        {

            {
                var tours = await context.Tours.ToListAsync();
                return mapper.Map<List<TourDTO>>(tours);

            }

        }

        [HttpGet("searchbyname")]

        public async Task<ActionResult<List<TourDTO>>> searchbyname(string tourName)
        {
            var tours = await context.Tours.Where(tourBD =>
            tourBD.TourName.Contains(tourName)).ToListAsync();//filtro
            return mapper.Map<List<TourDTO>>(tours);
        }



        [HttpGet("{id:int}")]


        public async Task<ActionResult<TourDTO>> Get(int id)
        {
            var tours = await context.Tours.Include(tourBD => tourBD.Guest).Include(tourBD => tourBD.Detail).Include(tourBD => tourBD.Challenge).FirstOrDefaultAsync(tourBD => tourBD.Id == id);
            if (tours == null)
            {
                return NotFound();
            }
            return mapper.Map<TourDTO>(tours);


        }




        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TourCreationDTO tourCreationDTO)
        {
            var existTourWithSameName = await context.Tours.AnyAsync(x => x.TourName == tourCreationDTO.TourName);
            if (existTourWithSameName)
            {
                return BadRequest($"That tour already exist.{tourCreationDTO.TourName}");
            }

            var tours = mapper.Map<Tour>(tourCreationDTO);



            context.Add(tours);
            await context.SaveChangesAsync();
            return Ok();
        }



    }
}