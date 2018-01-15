using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySharing.Data.Mapping
{
    public class UserAccountMap : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountMap()
        {
            this.HasKey(p => p.UserID)
                .Ignore(p => p.Id);
            this.Property(p => p.UserID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
