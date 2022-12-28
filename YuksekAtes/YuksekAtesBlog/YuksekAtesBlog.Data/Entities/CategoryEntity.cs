using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuksekAtesBlog.Data.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public List<PostEntity> Post { get; set; }
    }

    public class CategoryEntityConfiguration : BaseConfiguration<CategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            base.Configure(builder);
        }
    }
}
