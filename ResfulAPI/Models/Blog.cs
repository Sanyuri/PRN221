using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public int? BlogCategoryId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? Status { get; set; }
        public string? BlogImg { get; set; }
        public int? ParentId { get; set; }
        public string? Url { get; set; }

        public virtual BlogCategory? BlogCategory { get; set; }
        public virtual Account? CreatedByNavigation { get; set; }
        public virtual Account? ModifiedByNavigation { get; set; }
    }
}
