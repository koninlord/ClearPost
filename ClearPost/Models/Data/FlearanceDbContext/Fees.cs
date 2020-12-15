using System;
using System.Collections.Generic;

namespace ClearPost.Models.Data.FlearanceDbContext
{
    public partial class Fees: ISoftDelete
    {
        public int FeeId { get; set; }
        public string FeeAmount { get; set; }
        public string IsOwing { get; set; }
        public string AmountPaid { get; set; }
        public string AmountOwing { get; set; }
        public char RecStatus { get; set; } = 'A';
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
