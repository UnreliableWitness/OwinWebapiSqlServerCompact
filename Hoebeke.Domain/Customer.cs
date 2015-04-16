using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Hoebeke.Domain
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [MaxLength(4000)]
        public string Name { get; set; }
    }
}
