using System;
using System.Collections.Generic;

namespace ClearPost.Models.Data.FlearanceDbContext
{
    public partial class Halls : ISoftDelete
    {
        public int HallId { get; set; }
        public string HallName { get; set; }
        public string KeyReturned { get; set; }
        public string IsOwing { get; set; }
        public char RecStatus { get; set; } = 'A';
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
