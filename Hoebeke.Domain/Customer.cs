using System.Runtime.Serialization;

namespace Hoebeke.Domain
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
