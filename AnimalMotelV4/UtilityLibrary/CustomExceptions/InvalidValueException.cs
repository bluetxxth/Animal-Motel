using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesLibrary
{
   public class InvalidValueException : Exception
    {

        private static string msg = "Invalid value exception";
        public InvalidValueException() :base(msg)
        {

        }

    }
}
