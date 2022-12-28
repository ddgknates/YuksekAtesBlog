using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuksekAtesBlog.Data.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public string CategoryName { get; set; }
    }
}
