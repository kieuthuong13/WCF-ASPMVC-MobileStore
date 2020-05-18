namespace MyWCFService.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbStore : DbContext
    {
        public DbStore()
            : base("name=DbStore")
        {
        }

        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<discount> discounts { get; set; }
        public virtual DbSet<image> images { get; set; }
        public virtual DbSet<order_detail> order_detail { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<review> reviews { get; set; }
        public virtual DbSet<token> tokens { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<utoken> utokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.pwd)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .HasMany(e => e.tokens)
                .WithOptional(e => e.admin)
                .HasForeignKey(e => e.admin_id);

            modelBuilder.Entity<discount>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<discount>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<image>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<order_detail>()
                .Property(e => e.quantity)
                .IsUnicode(false);

            modelBuilder.Entity<order_detail>()
                .Property(e => e.money)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .Property(e => e.total_money)
                .IsUnicode(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_detail)
                .WithRequired(e => e.order)
                .HasForeignKey(e => e.order_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .Property(e => e.sku)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.Ghz)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.sensor)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.cpu)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.ram)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.storage)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.camera_front)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.camera_rear)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.battery)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.display)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.sim)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.comments)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<product>()
                .HasMany(e => e.images)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<product>()
                .HasMany(e => e.order_detail)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.posts)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<product>()
                .HasMany(e => e.reviews)
                .WithOptional(e => e.product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<token>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.pwd)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.comments)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.users_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.orders)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.users_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.reviews)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.users_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.utokens)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<utoken>()
                .Property(e => e.value)
                .IsUnicode(false);
        }
    }
}
