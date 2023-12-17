using Microsoft.EntityFrameworkCore;


namespace Seminar5
{
    public class ChatContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.77.137; username=postgres; Password=admin; Database=GB").UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("userPk");
                entity.ToTable("users");

                entity.HasIndex(x => x.FullName).IsUnique();

                entity.Property(e => e.FullName).HasColumnName("FullName").HasMaxLength(255).IsRequired();
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(x => x.MessageId).HasName("messagePk");
                entity.ToTable("messages");

                entity.Property(e => e.Text).HasColumnName("message_text");
                entity.Property(e => e.DataSend).HasColumnName("message_data");
                entity.Property(e => e.IsSent).HasColumnName("is_set");
                entity.Property(e => e.MessageId).HasColumnName("id");

                entity.HasOne(x => x.UserTo).WithMany(x => x.MessagesTo).HasForeignKey(x => x.UserToId).HasConstraintName("messageToUserFK");
                entity.HasOne(x => x.UserFrom).WithMany(x => x.MessagesFrom).HasForeignKey(x => x.UserFromId).HasConstraintName("messageFromUserFK");


            });
            base.OnModelCreating(modelBuilder);
        }

        public ChatContext() 
        {

        }

        public ChatContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
    }
}
