using System;
using System.Collections.Generic;
using System.Text;

namespace gps.codingtest.core.Services
{
    public class FailureToSendException : Exception
    {
        public FailureToSendException(string message)
            : base(message)
        {
        }

        public FailureToSendException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
