using System;
using System.Collections.Generic;
#nullable disable


namespace Models.Models
{
    public partial class FilterCategory
    {
        public int CatId { get; set; }
        public int FilterId { get; set; }

        public virtual Category Cat { get; set; }
        public virtual Filter Filter { get; set; }
    }
}
