using System.Runtime.Serialization;

namespace Kombit.Samples.Common.Binding.Data
{
    /// <summary>
    /// Fault data which will be response to client incase of receiving an invalid framework element in message header
    /// </summary>
    [DataContract]
    public class FrameworkFault
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public FrameworkFault()
        {
        }
        /// <summary>
        /// Contruct object with error message
        /// </summary>
        /// <param name="error"></param>
        public FrameworkFault(string error)
        {
            Details = error;
        }
        /// <summary>
        /// Details of error message
        /// </summary>
        [DataMember]
        public string Details { get; set; }
    }
}