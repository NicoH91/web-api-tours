namespace WebApiTours.DTOs
{
    public class ChallengeCreationDTO
    {
        public string TourChallenge { get; set; }

        public string Duration { get; set; }

        public string Stateroom { get; set; }

        public string RunAsDescription { get; set; }

        public string Discount { get; set; }

        public string Refund
        {
            get; set;
        }
    }
}
