using LandlordBackendAPI.Models;
using LandlordBackendAPI.Models.LandlordBackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LandlordBackendAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AsbestosBooking> AsbestosBookings { get; set; }
        public DbSet<Commercial_EICR> CommercialEICRs { get; set; }
        public DbSet<CommercialGasCertificate> CommercialGasCertificates { get; set; }
        public DbSet<EICR> EicrBookings { get; set; }
        public DbSet<EmergencyLightsTest> EmergencyLightsTests { get; set; }
        public DbSet<FireAlarm> FireAlarms { get; set; }
        public DbSet<FireDoor> FireDoors { get; set; }
        public DbSet<FireExtinguisher> FireExtinguishers { get; set; }
        public DbSet<FireRiskAssessment> FireRiskAssessments { get; set; }
        public DbSet<FireSafetyCertificate> FireSafetyCertificates { get; set; }
        public DbSet<FuseBox> FuseBoxes { get; set; }
        public DbSet<GasSafety> GasSafeties { get; set; }
        public DbSet<PAT> PATs { get; set; }
        public DbSet<Contact> ContactForms { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<EPC> EPCs { get; set; }




    }
}
