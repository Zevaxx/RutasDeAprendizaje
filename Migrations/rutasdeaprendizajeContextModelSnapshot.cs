﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RutasDeAprendizaje.Models.DBModels;

namespace RutasDeAprendizaje.Migrations
{
    [DbContext(typeof(rutasdeaprendizajeContext))]
    partial class rutasdeaprendizajeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tcommunity", b =>
                {
                    b.Property<int>("Comid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("COMID");

                    b.Property<string>("Comname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("COMNAME");

                    b.Property<int?>("Courseid")
                        .HasColumnType("int(11)")
                        .HasColumnName("COURSEID");

                    b.Property<int?>("Routeid")
                        .HasColumnType("int(11)")
                        .HasColumnName("ROUTEID");

                    b.Property<int>("Userid")
                        .HasColumnType("int(11)")
                        .HasColumnName("USERID");

                    b.HasKey("Comid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Userid" }, "FK_TRCOMUNITYHASUSERCREATOR");

                    b.HasIndex(new[] { "Courseid" }, "FK_TRCOURSEHASCOMMUNITY");

                    b.HasIndex(new[] { "Routeid" }, "FK_TRLEARNINGROUTESHASCOMUNITY");

                    b.ToTable("tcommunities");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tcourse", b =>
                {
                    b.Property<int>("Courseid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("COURSEID");

                    b.Property<int>("Comid")
                        .HasColumnType("int(11)")
                        .HasColumnName("COMID");

                    b.Property<string>("Coursename")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("COURSENAME");

                    b.Property<int?>("Coursescore")
                        .HasColumnType("int(11)")
                        .HasColumnName("COURSESCORE");

                    b.Property<int>("Coursetimelength")
                        .HasColumnType("int(11)")
                        .HasColumnName("COURSETIMELENGTH");

                    b.HasKey("Courseid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Comid" }, "FK_TRCOURSEHASCOMMUNITY2");

                    b.ToTable("tcourses");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tdiscipline", b =>
                {
                    b.Property<int>("Disciplineid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("DISCIPLINEID");

                    b.Property<string>("Disciplinename")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("DISCIPLINENAME");

                    b.HasKey("Disciplineid")
                        .HasName("PRIMARY");

                    b.ToTable("tdisciplines");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tlearningroute", b =>
                {
                    b.Property<int>("Routeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ROUTEID");

                    b.Property<int>("Comid")
                        .HasColumnType("int(11)")
                        .HasColumnName("COMID");

                    b.Property<int>("Routedificultlevel")
                        .HasColumnType("int(11)")
                        .HasColumnName("ROUTEDIFICULTLEVEL");

                    b.Property<string>("Routediscipline")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ROUTEDISCIPLINE");

                    b.Property<int?>("Routefollowers")
                        .HasColumnType("int(11)")
                        .HasColumnName("ROUTEFOLLOWERS");

                    b.Property<string>("Routename")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ROUTENAME");

                    b.Property<int?>("Routescore")
                        .HasColumnType("int(11)")
                        .HasColumnName("ROUTESCORE");

                    b.Property<int>("Userid")
                        .HasColumnType("int(11)")
                        .HasColumnName("USERID");

                    b.HasKey("Routeid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Userid" }, "FK_TRLEARNINGROUTECREATEDBYUSER");

                    b.HasIndex(new[] { "Comid" }, "FK_TRLEARNINGROUTESHASCOMUNITY2");

                    b.ToTable("tlearningroutes");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tpenalty", b =>
                {
                    b.Property<int>("Penalid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("PENALID");

                    b.Property<string>("Penalname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("PENALNAME");

                    b.Property<string>("Testpenaldescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("TESTPENALDESCRIPTION");

                    b.HasKey("Penalid")
                        .HasName("PRIMARY");

                    b.ToTable("tpenalties");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tpost", b =>
                {
                    b.Property<int>("Postid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("POSTID");

                    b.Property<int>("Comid")
                        .HasColumnType("int(11)")
                        .HasColumnName("COMID");

                    b.Property<string>("Postcontent")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("POSTCONTENT");

                    b.Property<DateTime?>("Postdate")
                        .HasColumnType("datetime")
                        .HasColumnName("POSTDATE");

                    b.Property<int>("Userid")
                        .HasColumnType("int(11)")
                        .HasColumnName("USERID");

                    b.HasKey("Postid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Comid" }, "FK_TRCOMMUNITYHASPOST");

                    b.HasIndex(new[] { "Userid" }, "FK_TRUSERHASPOST");

                    b.ToTable("tposts");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trcoursehastest", b =>
                {
                    b.Property<int>("Testid")
                        .HasColumnType("int(11)")
                        .HasColumnName("TESTID");

                    b.Property<int>("Courseid")
                        .HasColumnType("int(11)")
                        .HasColumnName("COURSEID");

                    b.HasKey("Testid", "Courseid")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "Courseid" }, "FK_TRCOURSEHASTEST2");

                    b.ToTable("trcoursehastest");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trcoursesinroute", b =>
                {
                    b.Property<int>("Courseid")
                        .HasColumnType("int(11)")
                        .HasColumnName("COURSEID");

                    b.Property<int>("Routeid")
                        .HasColumnType("int(11)")
                        .HasColumnName("ROUTEID");

                    b.HasKey("Courseid", "Routeid")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "Routeid" }, "FK_TRCOURSESINROUTE2");

                    b.ToTable("trcoursesinroute");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trlearningrouteshassuscriber", b =>
                {
                    b.Property<int>("Routeid")
                        .HasColumnType("int(11)")
                        .HasColumnName("ROUTEID");

                    b.Property<int>("Userid")
                        .HasColumnType("int(11)")
                        .HasColumnName("USERID");

                    b.HasKey("Routeid", "Userid")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "Userid" }, "FK_TRLEARNINGROUTESHASSUSCRIBERS2");

                    b.ToTable("trlearningrouteshassuscribers");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trole", b =>
                {
                    b.Property<int>("Rolid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("ROLID");

                    b.Property<string>("Roldetail")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ROLDETAIL");

                    b.Property<string>("Rolname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("ROLNAME");

                    b.HasKey("Rolid")
                        .HasName("PRIMARY");

                    b.ToTable("troles");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trrouteshasdiscipline", b =>
                {
                    b.Property<int>("Routeid")
                        .HasColumnType("int(11)")
                        .HasColumnName("ROUTEID");

                    b.Property<int>("Disciplineid")
                        .HasColumnType("int(11)")
                        .HasColumnName("DISCIPLINEID");

                    b.HasKey("Routeid", "Disciplineid")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "Disciplineid" }, "FK_TRROUTESHASDISCIPLINE2");

                    b.ToTable("trrouteshasdiscipline");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Truserhaspenalty", b =>
                {
                    b.Property<int>("Penalid")
                        .HasColumnType("int(11)")
                        .HasColumnName("PENALID");

                    b.Property<int>("Userid")
                        .HasColumnType("int(11)")
                        .HasColumnName("USERID");

                    b.HasKey("Penalid", "Userid")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "Userid" }, "FK_TRUSERHASPENALTY2");

                    b.ToTable("truserhaspenalty");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Truserhaverol", b =>
                {
                    b.Property<int>("Rolid")
                        .HasColumnType("int(11)")
                        .HasColumnName("ROLID");

                    b.Property<int>("Userid")
                        .HasColumnType("int(11)")
                        .HasColumnName("USERID");

                    b.HasKey("Rolid", "Userid")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "Userid" }, "FK_TRUSERHAVEROL2");

                    b.ToTable("truserhaverol");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trusershasdiscipline", b =>
                {
                    b.Property<int>("Userid")
                        .HasColumnType("int(11)")
                        .HasColumnName("USERID");

                    b.Property<int>("Disciplineid")
                        .HasColumnType("int(11)")
                        .HasColumnName("DISCIPLINEID");

                    b.HasKey("Userid", "Disciplineid")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "Disciplineid" }, "FK_TRUSERSHASDISCIPLINE2");

                    b.ToTable("trusershasdiscipline");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Ttest", b =>
                {
                    b.Property<int>("Testid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("TESTID");

                    b.Property<int?>("Testdifficultylevel")
                        .HasColumnType("int(11)")
                        .HasColumnName("TESTDIFFICULTYLEVEL");

                    b.Property<string>("Testname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("TESTNAME");

                    b.Property<string>("Testpenaldescription")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("TESTPENALDESCRIPTION");

                    b.HasKey("Testid")
                        .HasName("PRIMARY");

                    b.ToTable("ttests");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tuser", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("USERID");

                    b.Property<string>("Usercomunitypenalties")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("USERCOMUNITYPENALTIES");

                    b.Property<string>("Userloginstatus")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("USERLOGINSTATUS");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("USERNAME");

                    b.Property<string>("Userpassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("USERPASSWORD");

                    b.HasKey("Userid")
                        .HasName("PRIMARY");

                    b.ToTable("tusers");

                    b
                        .UseCollation("utf8mb4_unicode_ci");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tcommunity", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tcourse", "Course")
                        .WithMany("Tcommunities")
                        .HasForeignKey("Courseid")
                        .HasConstraintName("FK_TRCOURSEHASCOMMUNITY");

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tlearningroute", "Route")
                        .WithMany("Tcommunities")
                        .HasForeignKey("Routeid")
                        .HasConstraintName("FK_TRLEARNINGROUTESHASCOMUNITY");

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tuser", "User")
                        .WithMany("Tcommunities")
                        .HasForeignKey("Userid")
                        .HasConstraintName("FK_TRCOMUNITYHASUSERCREATOR")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Route");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tcourse", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tcommunity", "Com")
                        .WithMany("Tcourses")
                        .HasForeignKey("Comid")
                        .HasConstraintName("FK_TRCOURSEHASCOMMUNITY2")
                        .IsRequired();

                    b.Navigation("Com");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tlearningroute", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tcommunity", "Com")
                        .WithMany("Tlearningroutes")
                        .HasForeignKey("Comid")
                        .HasConstraintName("FK_TRLEARNINGROUTESHASCOMUNITY2")
                        .IsRequired();

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tuser", "User")
                        .WithMany("Tlearningroutes")
                        .HasForeignKey("Userid")
                        .HasConstraintName("FK_TRLEARNINGROUTECREATEDBYUSER")
                        .IsRequired();

                    b.Navigation("Com");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tpost", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tcommunity", "Com")
                        .WithMany("Tposts")
                        .HasForeignKey("Comid")
                        .HasConstraintName("FK_TRCOMMUNITYHASPOST")
                        .IsRequired();

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tuser", "User")
                        .WithMany("Tposts")
                        .HasForeignKey("Userid")
                        .HasConstraintName("FK_TRUSERHASPOST")
                        .IsRequired();

                    b.Navigation("Com");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trcoursehastest", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tcourse", "Course")
                        .WithMany("Trcoursehastests")
                        .HasForeignKey("Courseid")
                        .HasConstraintName("FK_TRCOURSEHASTEST2")
                        .IsRequired();

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Ttest", "Test")
                        .WithMany("Trcoursehastests")
                        .HasForeignKey("Testid")
                        .HasConstraintName("FK_TRCOURSEHASTEST")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trcoursesinroute", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tcourse", "Course")
                        .WithMany("Trcoursesinroutes")
                        .HasForeignKey("Courseid")
                        .HasConstraintName("FK_TRCOURSESINROUTE")
                        .IsRequired();

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tlearningroute", "Route")
                        .WithMany("Trcoursesinroutes")
                        .HasForeignKey("Routeid")
                        .HasConstraintName("FK_TRCOURSESINROUTE2")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trlearningrouteshassuscriber", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tlearningroute", "Route")
                        .WithMany("Trlearningrouteshassuscribers")
                        .HasForeignKey("Routeid")
                        .HasConstraintName("FK_TRLEARNINGROUTESHASSUSCRIBERS")
                        .IsRequired();

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tuser", "User")
                        .WithMany("Trlearningrouteshassuscribers")
                        .HasForeignKey("Userid")
                        .HasConstraintName("FK_TRLEARNINGROUTESHASSUSCRIBERS2")
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trrouteshasdiscipline", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tdiscipline", "Discipline")
                        .WithMany("Trrouteshasdisciplines")
                        .HasForeignKey("Disciplineid")
                        .HasConstraintName("FK_TRROUTESHASDISCIPLINE2")
                        .IsRequired();

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tlearningroute", "Route")
                        .WithMany("Trrouteshasdisciplines")
                        .HasForeignKey("Routeid")
                        .HasConstraintName("FK_TRROUTESHASDISCIPLINE")
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Truserhaspenalty", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tpenalty", "Penal")
                        .WithMany("Truserhaspenalties")
                        .HasForeignKey("Penalid")
                        .HasConstraintName("FK_TRUSERHASPENALTY")
                        .IsRequired();

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tuser", "User")
                        .WithMany("Truserhaspenalties")
                        .HasForeignKey("Userid")
                        .HasConstraintName("FK_TRUSERHASPENALTY2")
                        .IsRequired();

                    b.Navigation("Penal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Truserhaverol", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Trole", "Rol")
                        .WithMany("Truserhaverols")
                        .HasForeignKey("Rolid")
                        .HasConstraintName("FK_TRUSERHAVEROL")
                        .IsRequired();

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tuser", "User")
                        .WithMany("Truserhaverols")
                        .HasForeignKey("Userid")
                        .HasConstraintName("FK_TRUSERHAVEROL2")
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trusershasdiscipline", b =>
                {
                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tdiscipline", "Discipline")
                        .WithMany("Trusershasdisciplines")
                        .HasForeignKey("Disciplineid")
                        .HasConstraintName("FK_TRUSERSHASDISCIPLINE2")
                        .IsRequired();

                    b.HasOne("RutasDeAprendizaje.Models.DBModels.Tuser", "User")
                        .WithMany("Trusershasdisciplines")
                        .HasForeignKey("Userid")
                        .HasConstraintName("FK_TRUSERSHASDISCIPLINE")
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tcommunity", b =>
                {
                    b.Navigation("Tcourses");

                    b.Navigation("Tlearningroutes");

                    b.Navigation("Tposts");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tcourse", b =>
                {
                    b.Navigation("Tcommunities");

                    b.Navigation("Trcoursehastests");

                    b.Navigation("Trcoursesinroutes");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tdiscipline", b =>
                {
                    b.Navigation("Trrouteshasdisciplines");

                    b.Navigation("Trusershasdisciplines");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tlearningroute", b =>
                {
                    b.Navigation("Tcommunities");

                    b.Navigation("Trcoursesinroutes");

                    b.Navigation("Trlearningrouteshassuscribers");

                    b.Navigation("Trrouteshasdisciplines");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tpenalty", b =>
                {
                    b.Navigation("Truserhaspenalties");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Trole", b =>
                {
                    b.Navigation("Truserhaverols");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Ttest", b =>
                {
                    b.Navigation("Trcoursehastests");
                });

            modelBuilder.Entity("RutasDeAprendizaje.Models.DBModels.Tuser", b =>
                {
                    b.Navigation("Tcommunities");

                    b.Navigation("Tlearningroutes");

                    b.Navigation("Tposts");

                    b.Navigation("Trlearningrouteshassuscribers");

                    b.Navigation("Truserhaspenalties");

                    b.Navigation("Truserhaverols");

                    b.Navigation("Trusershasdisciplines");
                });
#pragma warning restore 612, 618
        }
    }
}
