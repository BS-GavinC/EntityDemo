using EntityDemo.context;
using EntityDemo.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDemo.configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.AccountCreation).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Firstname).HasMaxLength(50);
            builder.Property(x => x.Lastname).HasMaxLength(50);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasCheckConstraint("CK_EMAIL", "Email like '__%@__%._%'");
            
        }
    }
}
