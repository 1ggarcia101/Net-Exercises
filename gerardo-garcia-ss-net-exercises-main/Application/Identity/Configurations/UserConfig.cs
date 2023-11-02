using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Application.Identity.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Define the table name
            builder.ToTable("Users");

            // Define the primary key
            builder.HasKey(user => user.Id);

            // Map properties to columns
            builder.Property(user => user.Id).HasColumnName("UserId");
            builder.Property(user => user.FirstName).HasColumnName("FirstName");
            builder.Property(user => user.LastName).HasColumnName("LastName");
            builder.Property(user => user.Email).HasColumnName("Email");
            builder.Property(user => user.Password).HasColumnName("Password");
            builder.Property(user => user.UserType).HasColumnName("UserType");

            // Configure constraints or additional settings for properties
            builder.Property(user => user.Email).IsRequired(); // For example, make the email property required
        }
    }
}
