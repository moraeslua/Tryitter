using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Tryitter.src.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() {}

        public UnauthorizedException(string message) : base (message) {}
        
        public UnauthorizedException(string message, Exception innerException) : base (message, innerException) {}

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
