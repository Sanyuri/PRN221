using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst.Models
{
    [Table("Author")]
    public class Author
    {
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        [NotNull]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
