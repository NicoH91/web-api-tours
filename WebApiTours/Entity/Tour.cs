using System.Collections.Generic;

namespace WebApiTours.Entity
{
    public class Tour
    {

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string TourName { get; set; }

        public string Date { get; set; }

        public List<Guest> Guest { get; set; }

        public List<Detail> Detail { get; set; }

        public List<Challenge> Challenge { get; set; }

    }
}
