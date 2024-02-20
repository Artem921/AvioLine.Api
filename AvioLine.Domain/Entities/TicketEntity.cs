using AvioLine.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvioLine.Domain.Entities
{
    public class TicketEntity : EntityBase
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

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
