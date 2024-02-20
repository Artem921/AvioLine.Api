namespace AvioLine.Domain.DTO
{
    public class TicketDTO
    {
        public decimal Price { get; set; }

		public string Id { get; set; }
		public int Count { get; set; }
        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }

        public string Date { get => DateTime.Today.ToString("d"); }

        public string Time { get => DateTime.Now.ToLongTimeString(); }

        public string UserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }


    }
}
