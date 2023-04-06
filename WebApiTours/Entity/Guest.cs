namespace WebApiTours.Entity
{
    public class Guest
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int FinalCount { get; set; }


        public int TourId { get; set; }

        public Tour Tour { get; set; }

    }
}
