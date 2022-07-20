using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAMCandidateTestModels_MarkSeno
{
    [Serializable]
    public class Mineral
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public decimal Hardness { get; set; }
        public string Luster { get; set; }
        public string Color { get; set; }
        public string Streak { get; set; }
        public decimal SpecificGravity { get; set; }
        public string Diaphaneity { get; set; }
    }
}
