using System;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

#nullable disable

namespace RutasDeAprendizaje.Models.DBModels
{
  public partial class RutasdeaprendizajeContext : ApiAuthorizationDbContext<Tuser>
  {
    public RutasdeaprendizajeContext(
      DbContextOptions options,
      IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }

    //public rutasdeaprendizajeContext(DbContextOptions<rutasdeaprendizajeContext> options)
    //    : base(options)
    //{
    //}


    public virtual DbSet<Tcommunity> Tcommunities { get; set; }
    public virtual DbSet<Tcourse> Tcourses { get; set; }
    public virtual DbSet<Tdiscipline> Tdisciplines { get; set; }
    public virtual DbSet<Tlearningroute> Tlearningroutes { get; set; }
    public virtual DbSet<Tpenalty> Tpenalties { get; set; }
    public virtual DbSet<Tpost> Tposts { get; set; }
    public virtual DbSet<Trcoursehastest> Trcoursehastests { get; set; }
    public virtual DbSet<Trcoursesinroute> Trcoursesinroutes { get; set; }
    public virtual DbSet<Trlearningrouteshassuscriber> Trlearningrouteshassuscribers { get; set; }

    public virtual DbSet<Trrouteshasdiscipline> Trrouteshasdisciplines { get; set; }
    public virtual DbSet<Truserhaspenalty> Truserhaspenalties { get; set; }

    public virtual DbSet<Trusershasdiscipline> Trusershasdisciplines { get; set; }
    public virtual DbSet<Ttest> Ttests { get; set; }
    public virtual DbSet<Tuser> Tusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);


      modelBuilder.HasCharSet("utf8mb4")
          .UseCollation("utf8mb4_unicode_ci");



      modelBuilder.Entity<Tcommunity>(entity =>
      {
        entity.HasKey(e => e.Comid)
                  .HasName("PRIMARY");

        entity.ToTable("tcommunities");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Id, "FK_TRCOMUNITYHASUSERCREATOR");

        entity.HasIndex(e => e.Courseid, "FK_TRCOURSEHASCOMMUNITY");

        entity.HasIndex(e => e.Routeid, "FK_TRLEARNINGROUTESHASCOMUNITY");

        entity.Property(e => e.Comid)
                  .HasColumnType("int(11)")
                  .HasColumnName("COMID");

        entity.Property(e => e.Comname)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("COMNAME");

        entity.Property(e => e.Courseid)
                  .HasColumnType("int(11)")
                  .HasColumnName("COURSEID");

        entity.Property(e => e.Routeid)
                  .HasColumnType("int(11)")
                  .HasColumnName("ROUTEID");

        entity.Property(e => e.Id)

                  .HasColumnName("UserID");

        entity.HasOne(d => d.Course)
                  .WithMany(p => p.Tcommunities)
                  .HasForeignKey(d => d.Courseid)
                  .HasConstraintName("FK_TRCOURSEHASCOMMUNITY");

        entity.HasOne(d => d.Route)
                  .WithMany(p => p.Tcommunities)
                  .HasForeignKey(d => d.Routeid)
                  .HasConstraintName("FK_TRLEARNINGROUTESHASCOMUNITY");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Tcommunities)
                  .HasForeignKey(d => d.Id)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRCOMUNITYHASUSERCREATOR");
      });

      modelBuilder.Entity<Tcourse>(entity =>
      {
        entity.HasKey(e => e.Courseid)
                  .HasName("PRIMARY");

        entity.ToTable("tcourses");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Comid, "FK_TRCOURSEHASCOMMUNITY2");

        entity.Property(e => e.Courseid)
                  .HasColumnType("int(11)")
                  .HasColumnName("COURSEID");

        entity.Property(e => e.Comid)
                  .HasColumnType("int(11)")
                  .HasColumnName("COMID");

        entity.Property(e => e.Coursename)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("COURSENAME");

        entity.Property(e => e.Coursedescription)
                  .IsRequired()
                  .HasColumnName("COURSEDESCRIPTION");

        entity.Property(e => e.Coursescore)
                .HasColumnType("int(11)")
                .HasColumnName("COURSESCORE");

        entity.Property(e => e.Coursetimelength)
                  .HasColumnType("int(11)")
                  .HasColumnName("COURSETIMELENGTH");

        entity.HasOne(d => d.Com)
                  .WithMany(p => p.Tcourses)
                  .HasForeignKey(d => d.Comid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRCOURSEHASCOMMUNITY2");
      });

      modelBuilder.Entity<Tdiscipline>(entity =>
      {
        entity.HasKey(e => e.Disciplineid)
                  .HasName("PRIMARY");

        entity.ToTable("tdisciplines");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.Property(e => e.Disciplineid)
                  .HasColumnType("int(11)")
                  .HasColumnName("DISCIPLINEID");

        entity.Property(e => e.Disciplinename)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("DISCIPLINENAME");
      });

      modelBuilder.Entity<Tlearningroute>(entity =>
      {
        entity.HasKey(e => e.Routeid)
                  .HasName("PRIMARY");

        entity.ToTable("tlearningroutes");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Id, "FK_TRLEARNINGROUTECREATEDBYUSER");

        entity.HasIndex(e => e.Comid, "FK_TRLEARNINGROUTESHASCOMUNITY2");

        entity.Property(e => e.Routeid)
                  .HasColumnType("int(11)")
                  .HasColumnName("ROUTEID");

        entity.Property(e => e.Comid)
                  .HasColumnType("int(11)")
                  .HasColumnName("COMID");

        entity.Property(e => e.Routedificultlevel)
                  .HasColumnType("int(11)")
                  .HasColumnName("ROUTEDIFICULTLEVEL");

        entity.Property(e => e.Routediscipline)
                  .HasMaxLength(255)
                  .HasColumnName("ROUTEDISCIPLINE");

        entity.Property(e => e.Routefollowers)
                  .HasColumnType("int(11)")
                  .HasColumnName("ROUTEFOLLOWERS");

        entity.Property(e => e.Routename)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("ROUTENAME");

        entity.Property(e => e.Routedescription)
                .IsRequired()
                .HasColumnName("ROUTEDESCRIPTION");

        entity.Property(e => e.Routescore)
                .HasColumnType("int(11)")
                .HasColumnName("ROUTESCORE");

        entity.Property(e => e.Id)

                  .HasColumnName("UserId");

        entity.HasOne(d => d.Com)
                  .WithMany(p => p.Tlearningroutes)
                  .HasForeignKey(d => d.Comid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRLEARNINGROUTESHASCOMUNITY2");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Tlearningroutes)
                  .HasForeignKey(d => d.Id)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRLEARNINGROUTECREATEDBYUSER");
      });

      modelBuilder.Entity<Tpenalty>(entity =>
      {
        entity.HasKey(e => e.Penalid)
                  .HasName("PRIMARY");

        entity.ToTable("tpenalties");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.Property(e => e.Penalid)
                  .HasColumnType("int(11)")
                  .HasColumnName("PENALID");

        entity.Property(e => e.Penalname)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("PENALNAME");

        entity.Property(e => e.Testpenaldescription)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("TESTPENALDESCRIPTION");
      });

      modelBuilder.Entity<Tpost>(entity =>
      {
        entity.HasKey(e => e.Postid)
                  .HasName("PRIMARY");

        entity.ToTable("tposts");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Comid, "FK_TRCOMMUNITYHASPOST");

        entity.HasIndex(e => e.Id, "FK_TRUSERHASPOST");

        entity.Property(e => e.Postid)
                  .HasColumnType("int(11)")
                  .HasColumnName("POSTID");

        entity.Property(e => e.Comid)
                  .HasColumnType("int(11)")
                  .HasColumnName("COMID");

        entity.Property(e => e.Postcontent)
                  .IsRequired()
                  .HasMaxLength(1000)
                  .HasColumnName("POSTCONTENT");

        entity.Property(e => e.Postdate)
                  .HasColumnType("datetime")
                  .HasColumnName("POSTDATE");

        entity.Property(e => e.Id)

                  .HasColumnName("UserId");

        entity.HasOne(d => d.Com)
                  .WithMany(p => p.Tposts)
                  .HasForeignKey(d => d.Comid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRCOMMUNITYHASPOST");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Tposts)
                  .HasForeignKey(d => d.Id)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRUSERHASPOST");
      });

      modelBuilder.Entity<Trcoursehastest>(entity =>
      {
        entity.HasKey(e => new { e.Testid, e.Courseid })
                  .HasName("PRIMARY")
                  .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        entity.ToTable("trcoursehastest");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Courseid, "FK_TRCOURSEHASTEST2");

        entity.Property(e => e.Testid)
                  .HasColumnType("int(11)")
                  .HasColumnName("TESTID");

        entity.Property(e => e.Courseid)
                  .HasColumnType("int(11)")
                  .HasColumnName("COURSEID");

        entity.HasOne(d => d.Course)
                  .WithMany(p => p.Trcoursehastests)
                  .HasForeignKey(d => d.Courseid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRCOURSEHASTEST2");

        entity.HasOne(d => d.Test)
                  .WithMany(p => p.Trcoursehastests)
                  .HasForeignKey(d => d.Testid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRCOURSEHASTEST");
      });

      modelBuilder.Entity<Trcoursesinroute>(entity =>
      {
        entity.HasKey(e => new { e.Courseid, e.Routeid })
                  .HasName("PRIMARY")
                  .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        entity.ToTable("trcoursesinroute");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Routeid, "FK_TRCOURSESINROUTE2");

        entity.Property(e => e.Courseid)
                  .HasColumnType("int(11)")
                  .HasColumnName("COURSEID");

        entity.Property(e => e.Routeid)
                  .HasColumnType("int(11)")
                  .HasColumnName("ROUTEID");

        entity.HasOne(d => d.Course)
                  .WithMany(p => p.Trcoursesinroutes)
                  .HasForeignKey(d => d.Courseid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRCOURSESINROUTE");

        entity.HasOne(d => d.Route)
                  .WithMany(p => p.Trcoursesinroutes)
                  .HasForeignKey(d => d.Routeid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRCOURSESINROUTE2");
      });

      modelBuilder.Entity<Trlearningrouteshassuscriber>(entity =>
      {
        entity.HasKey(e => new { e.Routeid, e.Id })
                  .HasName("PRIMARY")
                  .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        entity.ToTable("trlearningrouteshassuscribers");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Id, "FK_TRLEARNINGROUTESHASSUSCRIBERS2");

        entity.Property(e => e.Routeid)
                  .HasColumnType("int(11)")
                  .HasColumnName("ROUTEID");

        entity.Property(e => e.Id)

                  .HasColumnName("UserId");

        entity.HasOne(d => d.Route)
                  .WithMany(p => p.Trlearningrouteshassuscribers)
                  .HasForeignKey(d => d.Routeid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRLEARNINGROUTESHASSUSCRIBERS");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Trlearningrouteshassuscribers)
                  .HasForeignKey(d => d.Id)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRLEARNINGROUTESHASSUSCRIBERS2");
      });

      modelBuilder.Entity<Trrouteshasdiscipline>(entity =>
      {
        entity.HasKey(e => new { e.Routeid, e.Disciplineid })
                  .HasName("PRIMARY")
                  .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        entity.ToTable("trrouteshasdiscipline");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Disciplineid, "FK_TRROUTESHASDISCIPLINE2");

        entity.Property(e => e.Routeid)
                  .HasColumnType("int(11)")
                  .HasColumnName("ROUTEID");

        entity.Property(e => e.Disciplineid)
                  .HasColumnType("int(11)")
                  .HasColumnName("DISCIPLINEID");

        entity.HasOne(d => d.Discipline)
                  .WithMany(p => p.Trrouteshasdisciplines)
                  .HasForeignKey(d => d.Disciplineid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRROUTESHASDISCIPLINE2");

        entity.HasOne(d => d.Route)
                  .WithMany(p => p.Trrouteshasdisciplines)
                  .HasForeignKey(d => d.Routeid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRROUTESHASDISCIPLINE");
      });

      modelBuilder.Entity<Truserhaspenalty>(entity =>
      {
        entity.HasKey(e => new { e.Penalid, e.Id })
                  .HasName("PRIMARY")
                  .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        entity.ToTable("truserhaspenalty");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Id, "FK_TRUSERHASPENALTY2");

        entity.Property(e => e.Penalid)
                  .HasColumnType("int(11)")
                  .HasColumnName("PENALID");

        entity.Property(e => e.Id)

                  .HasColumnName("UserId");

        entity.HasOne(d => d.Penal)
                  .WithMany(p => p.Truserhaspenalties)
                  .HasForeignKey(d => d.Penalid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRUSERHASPENALTY");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Truserhaspenalties)
                  .HasForeignKey(d => d.Id)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRUSERHASPENALTY2");
      });

      modelBuilder.Entity<Trusershasdiscipline>(entity =>
      {
        entity.HasKey(e => new { e.Id, e.Disciplineid })
                  .HasName("PRIMARY")
                  .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

        entity.ToTable("trusershasdiscipline");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.HasIndex(e => e.Disciplineid, "FK_TRUSERSHASDISCIPLINE2");

        entity.Property(e => e.Id)

                  .HasColumnName("UserId");

        entity.Property(e => e.Disciplineid)
                  .HasColumnType("int(11)")
                  .HasColumnName("DISCIPLINEID");

        entity.HasOne(d => d.Discipline)
                  .WithMany(p => p.Trusershasdisciplines)
                  .HasForeignKey(d => d.Disciplineid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRUSERSHASDISCIPLINE2");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Trusershasdisciplines)
                  .HasForeignKey(d => d.Id)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_TRUSERSHASDISCIPLINE");
      });

      modelBuilder.Entity<Ttest>(entity =>
      {
        entity.HasKey(e => e.Testid)
                  .HasName("PRIMARY");

        entity.ToTable("ttests");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.Property(e => e.Testid)
                  .HasColumnType("int(11)")
                  .HasColumnName("TESTID");

        entity.Property(e => e.Testdifficultylevel)
                  .HasColumnType("int(11)")
                  .HasColumnName("TESTDIFFICULTYLEVEL");

        entity.Property(e => e.Testname)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnName("TESTNAME");

        entity.Property(e => e.Testpenaldescription)
                  .HasMaxLength(255)
                  .HasColumnName("TESTPENALDESCRIPTION");
      });

      modelBuilder.Entity<Tuser>(entity =>
      {
        entity.HasKey(e => e.Id)
                  .HasName("PRIMARY");

        entity.ToTable("tusers");

        entity.UseCollation("utf8mb4_unicode_ci");

        entity.Property(e => e.Id)

                  .HasColumnName("UserId");

        entity.Property(e => e.Usercomunitypenalties)
                  .HasMaxLength(255)
                  .HasColumnName("USERCOMUNITYPENALTIES");

        entity.Property(e => e.UserDescription)

                  .HasMaxLength(255)
                  .HasColumnName("USERDESCRIPTION");

        //entity.Property(e => e.Username)
        //    .IsRequired()
        //    .HasMaxLength(50)
        //    .HasColumnName("USERNAME");

        //entity.Property(e => e.Userpassword)
        //    .IsRequired()
        //    .HasMaxLength(255)
        //    .HasColumnName("USERPASSWORD");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
