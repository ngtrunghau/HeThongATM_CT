using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TN213_DoAn.Models
{
    public partial class ATM_Data : DbContext
    {
        public ATM_Data()
            : base("name=ATM_Data")
        {
        }

        public virtual DbSet<ANHATM> ANHATMs { get; set; }
        public virtual DbSet<ANTOAN> ANTOANs { get; set; }
        public virtual DbSet<ATM> ATMs { get; set; }
        public virtual DbSet<CONGANKHUVUC> CONGANKHUVUCs { get; set; }
        public virtual DbSet<NGANHANG> NGANHANGs { get; set; }
        public virtual DbSet<QUANHUYEN> QUANHUYENs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<XAPHUONG> XAPHUONGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ANTOAN>()
                .Property(e => e.MOTAAT)
                .IsUnicode(false);

            modelBuilder.Entity<ANTOAN>()
                .HasMany(e => e.ATMs)
                .WithRequired(e => e.ANTOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ATM>()
                .Property(e => e.SDTATM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ATM>()
                .Property(e => e.MOCUAATM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ATM>()
                .Property(e => e.DONGCUAATM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CONGANKHUVUC>()
                .Property(e => e.SDTCA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CONGANKHUVUC>()
                .Property(e => e.DIACHICA)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.SDTTK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<XAPHUONG>()
                .HasMany(e => e.ATMs)
                .WithRequired(e => e.XAPHUONG)
                .WillCascadeOnDelete(false);
        }
    }
}
