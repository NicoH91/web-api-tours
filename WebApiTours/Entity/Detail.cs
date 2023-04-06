namespace WebApiTours.Entity
{
    public class Detail
    {
        public int Id { get; set; }

        public string Explanation { get; set; }


        public int TourId { get; set; }

        public Tour Tour { get; set; }
    }
}
