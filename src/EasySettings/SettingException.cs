using System;
using System.Collections.Generic;
using System.Text;

namespace EasySettings.Exceptions
{
    public class SettingException : Exception
    {
        public SettingException(string message) : base(message)
        {
        }

        public SettingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
