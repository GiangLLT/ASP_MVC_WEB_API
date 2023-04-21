using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        //DBset SQL server
        public DbSet<Model_API_Users> Users { get; set; }



        #region Dbset
        public DbSet<Header> Idoc_Header { get; set; }
        public DbSet<Body> Idoc_Item { get; set; }




        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations           
            modelBuilder.Entity<Body>(entity =>
            {
                entity.ToTable("Idoc_Item");
                entity.HasKey(e => e.IDocID);
                //e.Property(hi => hi.OutDate).HasDefaultValueSql("getutcdate()");
            });
            modelBuilder.Entity<Header>(entity =>
            {
                entity.ToTable("Idoc_Header");
                entity.HasKey(e => e.IDocNo);
                //entity.Property(hi => hi.OutDate).HasDefaultValueSql("getutcdate()");

                entity.HasMany(e => e.Body)
                .WithOne(e => e.header)
                .HasForeignKey(e => e.IDocNo)
                .HasConstraintName("FK_IDOCSAP_ITEM")
                .OnDelete(DeleteBehavior.Cascade);
            });


            //modelBuilder.Entity<IDocSAP>(entity => {
            //    entity.ToTable("Idoc_Header");
            //    //entity.HasKey(e => e.Header.IDocNo);
            //    entity.HasKey(e => e.Header.IDocNo);

            //    entity.HasOne(e => e.Body)
            //    .WithMany(e => e.Idoc_SAP)
            //    .HasForeignKey(e => e.Body.IDocNo)
            //    .HasConstraintName("FK_IDOCSAP_ITEM");
            //});


            //.Property(s => s.StudentId)
            //.HasColumnName("Id")
            //.HasDefaultValue(0)
            //.IsRequired();
        }
    }
}
