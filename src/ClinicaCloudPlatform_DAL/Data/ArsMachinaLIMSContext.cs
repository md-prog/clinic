using Microsoft.EntityFrameworkCore;
using ClinicaCloudPlatform.Model.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaCloudPlatform.DAL.Data
{
    public class ArsMachinaLIMSContext : DbContext
    {
        bool injectionDone = false;

        public ArsMachinaLIMSContext()
        {
        }

        public ArsMachinaLIMSContext(DbContextOptions<ArsMachinaLIMSContext> options)
        : base(options)
        {
            injectionDone = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!injectionDone)
                optionsBuilder.UseNpgsql("User ID=amlims;Password=P@ssw0rd;Host=arslinux1.westus.cloudapp.azure.com;Port=5432;Database=amlims_dev;Pooling=true;Keepalive=1;");
        }

        public DbSet<Accession> Accessions { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<PanelResult> PanelResults { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportTemplate> ReportTemplates { get; set; }
        public DbSet<Specimen> Specimens { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<Workflow> Workflows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            BaseMap(modelBuilder.Entity<Accession>());
            BaseMap(modelBuilder.Entity<Batch>());
            BaseMap(modelBuilder.Entity<Case>());
            BaseMap(modelBuilder.Entity<Client>());
            BaseMap(modelBuilder.Entity<Doctor>());
            BaseMap(modelBuilder.Entity<Facility>());
            BaseMap(modelBuilder.Entity<Lab>());
            BaseMap(modelBuilder.Entity<Label>());
            BaseMap(modelBuilder.Entity<PanelResult>());
            BaseMap(modelBuilder.Entity<Patient>());
            BaseMap(modelBuilder.Entity<Report>());
            BaseMap(modelBuilder.Entity<ReportDocument>());
            BaseMap(modelBuilder.Entity<ReportTemplate>());
            BaseMap(modelBuilder.Entity<Specimen>());
            BaseMap(modelBuilder.Entity<Step>());
            BaseMap(modelBuilder.Entity<TestResult>());
            //BaseMap(modelBuilder.Entity<User>());
            BaseMap(modelBuilder.Entity<Workflow>());
            //BaseMap(modelBuilder.Entity<WorklistConfiguration>());
            
            //data type/field/prop restrictions
            modelBuilder.Entity<Specimen>().Property(p => p.SpecimenCode).HasMaxLength(7);

            modelBuilder.Entity<Accession>().HasOne<Doctor>(a => a.Doctor1).WithMany();
            modelBuilder.Entity<Accession>().HasOne<Doctor>(a => a.Doctor2).WithMany();
            modelBuilder.Entity<Accession>().HasMany<Specimen>(a => a.Specimens);
            modelBuilder.Entity<Accession>().HasMany<Case>(a => a.Cases);

            modelBuilder.Entity<Case>().HasMany<Specimen>(a => a.Specimens);
            modelBuilder.Entity<Case>().HasMany<TestResult>(a => a.TestResults);
            modelBuilder.Entity<Case>().HasMany<PanelResult>(a => a.PanelResults);
            modelBuilder.Entity<Case>().HasOne<Lab>(a => a.ProcessingLab);
            modelBuilder.Entity<Case>().HasOne<Lab>(a => a.AnalysisLab);
            modelBuilder.Entity<Case>().HasOne<Lab>(a => a.ProfessionalLab);

            modelBuilder.Entity<Client>().HasMany<Facility>(a => a.Facilities);
            modelBuilder.Entity<Client>().HasMany<Doctor>(a => a.Doctors);

            modelBuilder.Entity<Report>().HasMany<ReportDocument>(a => a.ReportDocuments);
            modelBuilder.Entity<Report>().HasOne<ReportTemplate>(a => a.ReportTemplate);
        
            modelBuilder.Entity<Workflow>().HasMany<Step>(a => a.Steps);
        }

        protected void BaseMap<T>(EntityTypeBuilder<T> entityBuilder) where T : _LimsBaseClass
        {
            entityBuilder.HasKey(x => x.ID);
            entityBuilder.Property(x => x.ID).ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.ModifiedDate).ValueGeneratedOnAddOrUpdate();
            entityBuilder.Property(x => x.CreatedUUID).IsRequired(true);
            entityBuilder.Property(x => x.ModifiedUUID).IsRequired(true);
            entityBuilder.Property(x => x.JsonExtendedData).ForNpgsqlHasColumnType("jsonb");
        }
    }
}
