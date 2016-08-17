using System;

namespace TeleBot.API
{
    public class ApiRequestException : Exception
    {
        public ApiRequestException(string message) : base(message)
        {
        }

        public ApiRequestException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; internal set; }
    }
}