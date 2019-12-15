using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.DataAccess.Concrete.EntityFramework.Mappings
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            ToTable(@"Members", @"dbo");

            HasKey(c => c.Id);

            Property(c => c.FirstName).HasColumnName("FirstName");
            Property(c => c.LastName).HasColumnName("LastName");
            Property(c => c.DateOfBirth).HasColumnName("DateOfBirth");
            Property(c => c.TcNo).HasColumnName("TcNo");
            Property(c => c.Email).HasColumnName("Email");
        }
    }
}
