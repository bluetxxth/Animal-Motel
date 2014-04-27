
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;
using System.Xml.Serialization;

namespace AnimalLibrary
{
    [Serializable]
    [XmlInclude(typeof(Dog))]
    [XmlInclude(typeof(Cat))]
    public abstract class Mammal : Animal
    {

        public Mammal()
        {
            // TODO: Complete member initialization
        }


        /// <summary>
        /// Constructor - calls base constructor for extra information teeth anf quarantine
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="nickName"></param>
        /// <param name="age"></param>
        /// <param name="category"></param>
        /// <param name="gender"></param>
        /// <param name="numberOfTeeth"></param>
        /// <param name="quaranteen"></param>
        public Mammal(string ID, string nickName, int age, CategoryType category, GenderType gender, int numberOfTeeth, bool quaranteen, int numberOdDays)
            : base(string.Empty, string.Empty,age, category, gender, numberOfTeeth, quaranteen, numberOdDays)
        {


        }


        /// <summary>
        /// Abstract method establishes feeding data
        /// </summary>
        /// <returns></returns>
        public abstract string SetFeedingData();


        /// <summary>
        /// Abstract method string representation of mammal infor
        /// </summary>
        /// <returns></returns>
        public abstract string MammalInfo();





    } 

}
