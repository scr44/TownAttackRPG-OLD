using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleRPG.Models.Skills
{
    public class SkillNotReadyException : Exception
    {
        public SkillNotReadyException()
        {
        }

        public SkillNotReadyException(string message) : base(message)
        {
        }

        public SkillNotReadyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SkillNotReadyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
