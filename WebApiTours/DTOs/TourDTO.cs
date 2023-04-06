using System.Collections.Generic;

namespace WebApiTours.DTOs
{
    public class TourDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string TourName { get; set; }

        public string Date { get; set; }

        public List<GuestDTO> Guest { get; set; }

        public List<DetailDTO> Detail { get; set; }

        public List<ChallengeDTO> Challenge { get; set; }

    }
}
