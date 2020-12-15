using System;
using System.Collections.Generic;

namespace ClearPost.Models.Data.FlearanceDbContext
{
    public partial class Library
    {
        public int LibraryId { get; set; }
        public string HascollectedBook { get; set; }
        public string RecStatus { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
