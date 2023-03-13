using System;

namespace Assets.Code.Exceptions
{
    [Serializable]
    public class ComponentNotFoundException : Exception
    {
        public ComponentNotFoundException()
        { }

        public ComponentNotFoundException(string message) : base(message)
        {
        }

        protected ComponentNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}