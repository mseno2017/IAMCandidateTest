using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAMCandidateTestModels_MarkSeno
{
    [Serializable]
    public class Vegetable
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string EdiblePart { get; set; }

        public bool IsBotanicalFruit { get; set; }
    }
}
