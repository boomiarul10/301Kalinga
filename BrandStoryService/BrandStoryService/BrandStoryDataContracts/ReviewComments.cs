using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BrandStoryDataContracts
{
    [DataContract]
    public class ReviewComments
    {
        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public int Id { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public int BrandPost_Id { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public string ReviewComment { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public decimal SentimentScore { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public int CreatedBy { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public DateTime CreatedOn { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public int UpdatedBy { get; set; }

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public DateTime UpdatedOn { get; set; }
    }
}
