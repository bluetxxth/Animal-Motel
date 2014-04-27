using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitiesLibrary
{
   public  class NonExistentAnimalTypeException : Exception
    {

        private static string msg = "Animal type does not exist";

        public NonExistentAnimalTypeException()
            : base(msg)
        {

        }
    }
}
