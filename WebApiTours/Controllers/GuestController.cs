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
    [Route("api/Guest")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GuestController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }






        [HttpGet]
        public async Task<ActionResult<List<GuestDTO>>> Get(int tourId)
        {
            var guest = await context.Guests.
                Where(guestBD => guestBD.TourId == tourId).ToListAsync(); //cargamos el listado de sanciones que tenga su gv correspondiente

            return mapper.Map<List<GuestDTO>>(guest);

        }




        [HttpPost]

        public async Task<ActionResult> Post(int tourId, GuestCreationDTO guestCreationDTO)
        {
            var existTours = await context.Tours.AnyAsync(tourBD => tourBD.Id == tourId);

            if (!existTours)
            {
                return NotFound();
            }

            var guest = mapper.Map<Guest>(guestCreationDTO);
            guest.TourId = tourId;
            context.Add(guest);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
