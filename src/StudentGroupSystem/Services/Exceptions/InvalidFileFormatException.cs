using System;

namespace StudentGroupSystem.Services.Exceptions
{
    public class InvalidFileFormatException : Exception
    {
        public InvalidFileFormatException(string message)
            : base(message)
        {
        }
    }
}
