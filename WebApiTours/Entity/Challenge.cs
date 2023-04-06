namespace WebApiTours.Entity
{
    public class Challenge
    {
        public int Id { get; set; }

        public string TourChallenge { get; set; }

        public string Duration { get; set; }

        public string Stateroom { get; set; }

        public string RunAsDescription { get; set; }

        public string Discount { get; set; }

        public string Refund { get; set;}

        public int TourId { get; set; }

        public Tour Tour { get; set; }
    }
}
