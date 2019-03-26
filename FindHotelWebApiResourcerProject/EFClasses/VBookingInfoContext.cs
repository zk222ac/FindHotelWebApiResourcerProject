namespace FindHotelWebApiResourcerProject.EFClasses
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VBookingInfoContext : DbContext
    {
        public VBookingInfoContext()
            : base("name=VBookingInfoContext1")
        {
        }

        public virtual DbSet<BookingInfo> BookingInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingInfo>()
                .Property(e => e.HotelName)
                .IsUnicode(false);

            modelBuilder.Entity<BookingInfo>()
                .Property(e => e.RoomType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BookingInfo>()
                .Property(e => e.GuestName)
                .IsUnicode(false);
        }
    }
}
