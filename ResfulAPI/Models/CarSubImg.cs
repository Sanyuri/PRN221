using System;
using System.Collections.Generic;

namespace ResfulAPI.Models
{
    public partial class CarSubImg
    {
        public int? CarId { get; set; }
        public int CarSubImgtypeId { get; set; }
        public string? CarSubImg1 { get; set; }

        public virtual Car? Car { get; set; }
        public virtual CarSubImgtype CarSubImgtype { get; set; } = null!;
    }
}
