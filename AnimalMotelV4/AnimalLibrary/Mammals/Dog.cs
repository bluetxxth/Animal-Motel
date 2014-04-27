
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
    public class Dog : Mammal
    {

        public Dog():base()
        {

        }

        public Dog(string ID, string nickName, int age, CategoryType category, GenderType gender, int numberOfTeeth, bool quaranteen, int numberOfDays)
            : base(string.Empty, string.Empty, age, category, gender,numberOfTeeth, quaranteen, numberOfDays )
        {

        }



                /// <summary>
        /// Method overrides GetAnimalSpeficData()
        /// </summary>
        /// <returns>overriden string </returns>
        public override string GetAnimalSpecificData()
        {


            string strOut = null;

            string leashWalking = "NO";

            strOut += Environment.NewLine + "Leach walking " + leashWalking;
            strOut += Environment.NewLine + SetFeedingData();
            strOut +=  Environment.NewLine +  MammalInfo();
      

            return strOut;
            
        }



        //A VG (ECT A and B) part
        //An abstract method for sub classes
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        /// </summary>
        public override string SetFeedingData()
        {
            string strOut = Environment.NewLine + "Needs to be walked 5 times a day";

            return strOut;

        }

        ///// <summary>
        ///// Overriden method shows animal info
        ///// </summary>
        ///// <returns></returns>
        //public override string AnimalInfo()
        //{
        //    string strOut = null;

        //    strOut = string.Format("\t{0,-20}{1, -20}{2, -3}{3, -5}", m_animalID, m_nickName, m_animalAge, m_animalCategory, m_animalGender);

        //    return strOut;

        //}

        /// <summary>
        /// Overriden Method calls base method
        /// </summary>
        /// <returns></returns>
        public override string MammalInfo()
        {
            string strOut = null;


            strOut = base.MammalData();

            return strOut;
        }


    }


}