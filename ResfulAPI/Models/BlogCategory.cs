using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class BlogCategory
    {
        public BlogCategory()
        {
            Blogs = new HashSet<Blog>();
        }

        public int BlogCategoryId { get; set; }
        public string? BlogCategory1 { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
