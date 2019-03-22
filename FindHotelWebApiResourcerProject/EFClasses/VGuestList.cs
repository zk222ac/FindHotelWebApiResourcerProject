using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindHotelWebApiResourcerProject.EFClasses
{
    [Table("VGuestList")]
    public partial class VGuestList
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string HotelName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string GuestName { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime DateFrom { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime DateTo { get; set; }
    }
}
