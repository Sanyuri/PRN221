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
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        [Column("title")]
        [NotNull]
        [MaxLength(100)]
        public string Title { get; set; }

        [Column("publish_year")]
        [NotNull]
        public int PublishYear { get; set; }

        [Column("author_id")]
        [NotNull]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public override string ToString()
        {
            return $"{Title} ({PublishYear})";
        }
    }
}
