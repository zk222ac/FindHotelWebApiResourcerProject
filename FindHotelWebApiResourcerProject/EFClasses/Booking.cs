using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindHotelWebApiResourcerProject.EFClasses
{
    [Table("Booking")]
    public partial class Booking
    {
        public int BookingId { get; set; }

        public int HotelNo { get; set; }

        public int GuestNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTo { get; set; }

        public int RoomNo { get; set; }

        public virtual Guest Guest { get; set; }

        public virtual Guest Guest1 { get; set; }

        public virtual Room Room { get; set; }

        public virtual Room Room1 { get; set; }
    }
}
