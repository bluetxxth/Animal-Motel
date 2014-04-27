
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AnimalLibrary
{
    [Serializable]
    [XmlInclude(typeof(Cat))]
    public class Cat : Mammal
    {



        /// <summary>
        /// Construytor calls base constructor
        /// </summary>
        public Cat(): base()
        {


        }


        [XmlElement("Quarantine")]
        /// <summary>
        /// 
        /// </summary>
        public override bool Quarantine
        {
            get
            {
                return base.Quarantine;
            }
            set
            {
                base.Quarantine = value;
            }
        }



        /// <summary>
        /// Method overrides GetAnimalSpeficData()
        /// </summary>
        /// <returns>overriden string </returns>
        public override string GetAnimalSpecificData()
        {

            string strOut = null;

            strOut += null;
            strOut += Environment.NewLine + SetFeedingData();
            Console.WriteLine();
            Console.WriteLine();
            strOut += MammalInfo();

            return strOut;

        }


        /// <summary>
        /// Method string representation of mammal data
        /// </summary>
        /// <returns></returns>
        public override string MammalInfo()
        {
            string strOut = null;


            strOut = base.MammalData();

            return strOut;
        }


        ///// <summary>
        ///// String representation of animal info
        ///// </summary>
        ///// <returns></returns>
        //public override string AnimalInfo()
        //{
        //    string strOut = null;

        //    strOut = string.Format("\t{0,-20}{1, -20}{2, -3}{3, -5}", m_animalID, m_nickName, m_animalAge, m_animalCategory, m_animalGender);

        //    return strOut;

        //}


        //A VG (ECT A and B) part
        //An abstract method for sub classes
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        /// </summary>
        public override string SetFeedingData()
        {
            string strOut = "Needs to be walked 5 times a day" + "\n";

            return strOut;

        }


    }



}