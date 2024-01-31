using MessageService.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MessageService.Db
{
    public partial class MessageContext : DbContext
    {
        private readonly string _connectionString;

        public virtual DbSet<MessageModel> Messages{ get; set; }
        


        public MessageContext() { }

        public MessageContext(string connectionString)
        {
            _connectionString = connectionString;

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageModel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pkey");
                

                entity.ToTable("messages");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Message).HasMaxLength(1000).HasColumnName("message");

                entity.Property(e => e.ForUserName).HasColumnName("for_user_name");
                entity.Property(e => e.FromUserName).HasColumnName("from_user_name");

                entity.Property(e => e.Read).HasConversion<bool>();
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

