using System.Data.Entity;

namespace FindHotelWebApiResourcerProject.EFClasses
{
    public partial class ViewGuestListContext : DbContext
    {
        public ViewGuestListContext()
            : base("name=ViewGuestListContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<VGuestList> VGuestLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VGuestList>()
                .Property(e => e.HotelName)
                .IsUnicode(false);

            modelBuilder.Entity<VGuestList>()
                .Property(e => e.GuestName)
                .IsUnicode(false);
        }
    }
}
