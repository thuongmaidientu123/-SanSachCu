namespace web1._0.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SanSachCu : DbContext
    {
        public SanSachCu()

            : base("name=Long")

            

        {
        }

        public virtual DbSet<BaiDang> BaiDangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiDang>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .HasMany(e => e.BaiDangs)
                .WithRequired(e => e.NhaXuatBan)
                .HasForeignKey(e => e.manxb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaXuatBan>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.NhaXuatBan)
                .HasForeignKey(e => e.manxb)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.Sach)
                .HasForeignKey(e => e.masach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TacGia>()
                .HasMany(e => e.BaiDangs)
                .WithRequired(e => e.TacGia)
                .HasForeignKey(e => e.matacgia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TacGia>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.TacGia)
                .HasForeignKey(e => e.matacgia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.BaiDangs)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.mataikhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.TaiKhoan)
                .HasForeignKey(e => e.mataikhoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.BaiDangs)
                .WithRequired(e => e.TheLoai)
                .HasForeignKey(e => e.matheloai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.TheLoai)
                .HasForeignKey(e => e.matheloai)
                .WillCascadeOnDelete(false);
        }
    }
}
