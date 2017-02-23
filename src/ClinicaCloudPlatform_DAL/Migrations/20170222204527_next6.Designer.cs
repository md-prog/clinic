using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ClinicaCloudPlatform.DAL.Data;
using ClinicaCloudPlatform.Model.Models;

namespace ClinicaCloudPlatform.DAL.Migrations
{
    [DbContext(typeof(ArsMachinaLIMSContext))]
    [Migration("20170222204527_next6")]
    partial class next6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Accession", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("ClientID");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<int?>("Doctor1ID");

                    b.Property<int?>("Doctor2ID");

                    b.Property<int?>("FacilityID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("MRN");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<int?>("OrderingLabID");

                    b.Property<int?>("PatientID");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("Doctor1ID");

                    b.HasIndex("Doctor2ID");

                    b.HasIndex("FacilityID");

                    b.HasIndex("OrderingLabID");

                    b.HasIndex("PatientID");

                    b.ToTable("Accessions");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Barcode", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("Number");

                    b.HasKey("ID");

                    b.ToTable("Barcode");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Batch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("BatchNumber");

                    b.Property<string>("BatchStatus");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Case", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccessionID");

                    b.Property<bool>("Active");

                    b.Property<int?>("AnalysisLabID");

                    b.Property<string>("CaseNumber");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<int?>("ProcessingLabID");

                    b.Property<int?>("ProfessionalLabID");

                    b.HasKey("ID");

                    b.HasIndex("AccessionID");

                    b.HasIndex("AnalysisLabID");

                    b.HasIndex("ProcessingLabID");

                    b.HasIndex("ProfessionalLabID");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("ClientCode");

                    b.Property<string>("ClientName");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CommentText");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedFullName");

                    b.Property<string>("CreatedHref");

                    b.Property<string>("JsonExtendedData");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ModifiedFullName");

                    b.Property<string>("ModifiedHref");

                    b.Property<string>("SecondaryIdentifier");

                    b.HasKey("ID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("ClientID");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Facility", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<int?>("ClientID");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<string>("PostalCode");

                    b.Property<string>("StateProvince");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Lab", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("LabCode");

                    b.Property<string>("LabName");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Labs");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Label", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("BarcodeFormDefinition");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("LabelName");

                    b.Property<int>("LabelType");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.PanelResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("CaseID");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("PanelCode");

                    b.Property<string>("PanelName");

                    b.HasKey("ID");

                    b.HasIndex("CaseID");

                    b.ToTable("PanelResults");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Patient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<DateTime>("DOB");

                    b.Property<string>("FirstName");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("SSN");

                    b.HasKey("ID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Report", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("CaseID");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<int?>("ReportTemplateID");

                    b.Property<int>("ReportVersion");

                    b.Property<string>("ReportVersionNotes");

                    b.HasKey("ID");

                    b.HasIndex("CaseID");

                    b.HasIndex("ReportTemplateID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportDocument", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<byte[]>("ReportDocumentBinary");

                    b.Property<int>("ReportDocumentType");

                    b.Property<int?>("ReportID");

                    b.HasKey("ID");

                    b.HasIndex("ReportID");

                    b.ToTable("ReportDocument");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportTemplate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<bool>("PublicReport");

                    b.Property<string>("ReportTemplateDefinition");

                    b.Property<string>("ReportTemplateName");

                    b.HasKey("ID");

                    b.ToTable("ReportTemplates");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Specimen", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccessionID");

                    b.Property<bool>("Active");

                    b.Property<int?>("BatchID");

                    b.Property<int?>("CaseID");

                    b.Property<DateTime>("CollectionDate");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("ExternalSpecimenID");

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<int>("ParentSpecimenID");

                    b.Property<DateTime>("ReceivedDate");

                    b.Property<string>("SpecimenCategory");

                    b.Property<string>("SpecimenCode")
                        .HasMaxLength(7);

                    b.Property<string>("SpecimenTransport");

                    b.Property<string>("SpecimenType");

                    b.HasKey("ID");

                    b.HasIndex("AccessionID");

                    b.HasIndex("BatchID");

                    b.HasIndex("CaseID");

                    b.ToTable("Specimens");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Step", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.Property<int?>("WorkflowID");

                    b.HasKey("ID");

                    b.HasIndex("WorkflowID");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.TestResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int?>("BatchID");

                    b.Property<int?>("CaseID");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("TestCode");

                    b.Property<string>("TestName");

                    b.HasKey("ID");

                    b.HasIndex("BatchID");

                    b.HasIndex("CaseID");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Workflow", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedFullName")
                        .IsRequired();

                    b.Property<string>("CreatedHref")
                        .IsRequired();

                    b.Property<string>("JsonExtendedData")
                        .HasAnnotation("Npgsql:ColumnType", "jsonb");

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ModifiedFullName")
                        .IsRequired();

                    b.Property<string>("ModifiedHref")
                        .IsRequired();

                    b.Property<string>("WorkflowName");

                    b.HasKey("ID");

                    b.ToTable("Workflows");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Accession", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Doctor", "Doctor1")
                        .WithMany()
                        .HasForeignKey("Doctor1ID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Doctor", "Doctor2")
                        .WithMany()
                        .HasForeignKey("Doctor2ID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "OrderingLab")
                        .WithMany()
                        .HasForeignKey("OrderingLabID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Case", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithMany("Cases")
                        .HasForeignKey("AccessionID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "AnalysisLab")
                        .WithMany()
                        .HasForeignKey("AnalysisLabID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "ProcessingLab")
                        .WithMany()
                        .HasForeignKey("ProcessingLabID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Lab", "ProfessionalLab")
                        .WithMany()
                        .HasForeignKey("ProfessionalLabID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Doctor", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Client")
                        .WithMany("Doctors")
                        .HasForeignKey("ClientID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Facility", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Client")
                        .WithMany("Facilities")
                        .HasForeignKey("ClientID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.PanelResult", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("PanelResults")
                        .HasForeignKey("CaseID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Report", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case", "Case")
                        .WithMany()
                        .HasForeignKey("CaseID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.ReportTemplate", "ReportTemplate")
                        .WithMany()
                        .HasForeignKey("ReportTemplateID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.ReportDocument", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Report")
                        .WithMany("ReportDocuments")
                        .HasForeignKey("ReportID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Specimen", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Accession")
                        .WithMany("Specimens")
                        .HasForeignKey("AccessionID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Batch")
                        .WithMany("Specimens")
                        .HasForeignKey("BatchID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("Specimens")
                        .HasForeignKey("CaseID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.Step", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Workflow")
                        .WithMany("Steps")
                        .HasForeignKey("WorkflowID");
                });

            modelBuilder.Entity("ClinicaCloudPlatform.Model.Models.TestResult", b =>
                {
                    b.HasOne("ClinicaCloudPlatform.Model.Models.Batch")
                        .WithMany("TestResults")
                        .HasForeignKey("BatchID");

                    b.HasOne("ClinicaCloudPlatform.Model.Models.Case")
                        .WithMany("TestResults")
                        .HasForeignKey("CaseID");
                });
        }
    }
}
