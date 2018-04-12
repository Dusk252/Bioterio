using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Controlo
    {
        public int EntryId { get; set; }
        public string TableName { get; set; }
        public string AttributeName { get; set; }
        public float? LowerBound { get; set; }
        public float? UpperBound { get; set; }
    }
}
