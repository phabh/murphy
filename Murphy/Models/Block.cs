using System;
using System.Runtime.Serialization;
using Lime.Protocol;

namespace Murphy.Models
{
    [DataContract]
    public class Block
    {
        [DataMember(Name = "blockid")]
        public Guid BlockId { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "messages")]
        public Document[] Messages { get; set; }
    }
}