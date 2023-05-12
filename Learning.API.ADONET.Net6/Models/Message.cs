using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Learning.API.ADONET.Net6.Models
{
    public class Message<T>
    {
        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }

        [DataMember(Name = "ReturnMessage")]
        public string ReturnMessage { get; set; }

        [DataMember(Name = "Data")]
        public T Data { get; set; }

    }
}
