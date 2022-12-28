using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuksekAtesBlog.Data.Entities
{
    public class PostEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Summary { get; set; }
        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }
    }

    public class PostEntityConfiguration : BaseConfiguration<PostEntity>
    {
        public override void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired();
            builder.Property(x => x.Summary).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();

            base.Configure(builder);
        }
    }
}
