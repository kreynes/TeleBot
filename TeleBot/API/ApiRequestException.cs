using System;

namespace TeleBot.API
{
    public class ApiRequestException : Exception
    {

        public int ErrorCode { get; internal set; }

        public ApiRequestException(string message)
        {
        }

        public ApiRequestException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

