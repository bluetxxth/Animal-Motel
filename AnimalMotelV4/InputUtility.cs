
//
//Class inputUtility takes care of the input validation
//Gabriel Nieva M12K2712
//
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnimalMotelV4
{
    class InputUtility
    {
        public InputUtility()
        {

        }





        /// <summary>
        /// Converts a string representated double value into an double type, and validates
        /// </summary>
        /// <param name="stringToConvert">string representing the Integer value</param>
        /// <param name="intOutValue">ouput parameter, the converted Integer value</param>
        /// <returns>true if the conversion is successful and the converted value is within the given range</returns>
        public static bool GetInt(string stringToConvert1,
                                     string stringToConvert2,
                                     string stringToConvert3,
                                     out int intOutValue1,
                                     out int intOutValue2,
                                      out int intOutValue3)
        {


            bool isTrue = false;


            if ((int.TryParse(stringToConvert1, out intOutValue1)) && intOutValue1 > 0)
            {

                isTrue = true;
            }

            if ((int.TryParse(stringToConvert2, out intOutValue2)) && intOutValue2 > 0)
            {

                isTrue = true;
            }


            if ((int.TryParse(stringToConvert3, out intOutValue3)) && intOutValue3 > 0)
            {
                isTrue = true;
            }

            else
            {
                isTrue = false;
            }//end if else
            return isTrue;
        }//end function




        /// <summary>
        /// Converts a string representated double value into an double type, and validates
        /// </summary>
        /// <param name="stringToConvert">string representing the Integer value</param>
        /// <param name="intOutValue">ouput parameter, the converted Integer value</param>
        /// <returns>true if the conversion is successful and the converted value is within the given range</returns>
        public static bool GetInt(string stringToConvert1,
                                     string stringToConvert2,
                                     out int intOutValue1,
                                     out int intOutValue2)
        {


            bool isTrue = false;


            if ((int.TryParse(stringToConvert1, out intOutValue1)) && intOutValue1 > 0)
            {

                isTrue = true;
            }

            if ((int.TryParse(stringToConvert2, out intOutValue2)) && intOutValue2 > 0)
            {

                isTrue = true;
            }

            else
            {
                isTrue = false;
            }//end if else
            return isTrue;
        }//end function


        /// <summary>
        /// Converts a string representated double value into an double type, and validates
        /// </summary>
        /// <param name="stringToConvert">string representing the Integer value</param>
        /// <param name="intOutValue">ouput parameter, the converted Integer value</param>
        /// <returns>true if the conversion is successful and the converted value is within the given range</returns>
        public static bool GetIntAndDouble(string stringToConvert1,
                                     string stringToConvert2,
                                     out int intOutValue1,
                                     out double dblOutValue2)
        {


            bool isTrue = false;


            if ((int.TryParse(stringToConvert1, out intOutValue1)) && intOutValue1 > 0 )
            {

                isTrue = true;
            }


            if ((double.TryParse(stringToConvert2, out dblOutValue2)) && dblOutValue2 > 0)
            {

                isTrue = true;
            }

            else
            {
                isTrue = false;
            }//end if else
            return isTrue;
        }//end function


        /// <summary>
        /// Converts a string representated double value into an double type, and validates
        /// </summary>
        /// <param name="stringToConvert">string representing the Integer value</param>
        /// <param name="intOutValue">ouput parameter, the converted Integer value</param>
        /// <returns>true if the conversion is successful and the converted value is within the given range</returns>
        public static bool getIntAndDouble(string stringToConvert1,
                                     string stringToConvert2, 
                                     string stringToConvert3,               
                                     out int intOutValue1,
                                     out int intOutValue2,
                                     out double dblOutValue3)
        {


            bool isTrue = false;


            if ((int.TryParse(stringToConvert1, out intOutValue1)) && intOutValue1 > 0)
            {

                isTrue = true;
            }


            if ((int.TryParse(stringToConvert2, out intOutValue2)) && intOutValue2 > 0)
            {
                isTrue = true;
            }

            if ((double.TryParse(stringToConvert3, out dblOutValue3)) && dblOutValue3 > 0)
            {
                isTrue = true;
            }

            else
            {
                isTrue = false;
            }//end if else
            return isTrue;
        }//end function


        /// <summary>
        /// Converts a string representated double value into an double type, and validates
        /// </summary>
        /// <param name="stringToConvert">string representing the Integer value</param>
        /// <param name="intOutValue">ouput parameter, the converted Integer value</param>
        /// <returns>true if the conversion is successful and the converted value is within the given range</returns>
        public static bool GetInt(string stringToConvert1,
                                     out int intOutValue1)
        {


            bool isTrue = false;


            if ((int.TryParse(stringToConvert1, out intOutValue1)) && intOutValue1 > 0)
            {

                isTrue = true;
            }
           
            else
            {
                isTrue = false;
            }//end if else
            return isTrue;
        }//end function


        /// <summary>
        /// Converts a string representated double value into an double type, and validates
        /// </summary>
        /// <param name="stringToConvert">string representing the Integer value</param>
        /// <param name="intOutValue">ouput parameter, the converted Integer value</param>
        /// <returns>true if the conversion is successful and the converted value is within the given range</returns>
        public static bool GetDouble(string stringToConvert1,
                                     out double dblOutValue1)
        {


            bool isTrue = false;


            if ((double.TryParse(stringToConvert1, out dblOutValue1)) && dblOutValue1 > 0)
            {

                isTrue = true;
            }

            else
            {
                isTrue = false;
            }//end if else
            return isTrue;
        }//end function




    }//end class
}//end namespace