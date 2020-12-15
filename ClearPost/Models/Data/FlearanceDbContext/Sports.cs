using System;
using System.Collections.Generic;

namespace ClearPost.Models.Data.FlearanceDbContext
{
    public partial class Sports: ISoftDelete
    {
        public int SportId { get; set; }
        public string SportsType { get; set; }
        public string IsOwingKit { get; set; }
        public char RecStatus { get; set; } = 'A';
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
