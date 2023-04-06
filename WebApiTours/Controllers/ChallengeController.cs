using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using WebApiTours.DTOs;
using WebApiTours.Entity;

namespace WebApiTours.Controllers
{
    [Route("api/Challenge")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ChallengeController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<ChallengeDTO>>> Get(int tourId)
        {
            var challenge = await context.Challenges.
                Where(challengeBD => challengeBD.TourId == tourId).ToListAsync();

            return mapper.Map<List<ChallengeDTO>>(challenge);

        }


        [HttpPost]

        public async Task<ActionResult> Post(int tourId, ChallengeCreationDTO challengeCreationDTO)
        {
            var existTours = await context.Tours.AnyAsync(tourBD => tourBD.Id == tourId);

            if (!existTours)
            {
                return NotFound();
            }

            var challenge = mapper.Map<Challenge>(challengeCreationDTO);
            challenge.TourId = tourId;
            context.Add(challenge);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
