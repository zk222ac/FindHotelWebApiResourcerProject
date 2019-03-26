namespace FindHotelWebApiResourcerProject.EFClasses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingInfo")]
    public partial class BookingInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string HotelName { get; set; }

        [StringLength(1)]
        public string RoomType { get; set; }

        public double? RoomPrice { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string GuestName { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime FromDate { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime ToDate { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomNo { get; set; }
    }
}
