using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prototipo.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo.Service.Configurations
{
  public class UserInfoEntityTypeConfiguration : IEntityTypeConfiguration<UserInfo>
  {
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id)
        .HasColumnName("id");

      builder.Property(x => x.UserName)
        .HasColumnName("username");

      builder.Property(x => x.Gender)
        .HasColumnName("gender");

      builder.Property(x => x.DOB)
        .HasColumnName("dob");
      //builder
      // .Property(u => u.DOB)
      // .HasColumnType("timestamp without time zone");

      builder.ToTable("userinfo", "cust");
    }
  }
}
