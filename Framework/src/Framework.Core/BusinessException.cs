using System;

namespace Framework.Core
{
    public class BusinessException : Exception
    {
        public long ErrorCode { get; private set; }
        public BusinessException(long errorCode, string message): base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}
