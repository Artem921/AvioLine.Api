using System.ComponentModel.DataAnnotations;

namespace AvioLine.Domain.Models
{
    public class TicketViewModel
    {
		public string Id { get; set; }
		public decimal Price { 
            get
            {
                return 2300 * Count;
            }
        }

        [Required]
        public int Count { get; set; }

        [Required]
        public string DepartureCity { get; set; }

        [Required]
        public string ArrivalCity { get; set; }

        public string Date { get => DateTime.Today.ToString("d"); }

        public string? UserId { get; set; }
        public string Time { get => DateTime.Now.ToLongTimeString(); }
        [Required]
        [Display(Name = "Имя")]
        public string UserFirstName { get; set; }
        [Required]
        public string UserLastName { get; set; }
    }
}
