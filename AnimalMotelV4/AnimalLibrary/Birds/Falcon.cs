
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;



namespace AnimalLibrary
{

    public class Falcon : Bird
    {

        //instance variables
        private bool m_bornInCaptivity;


        /// <summary>
        /// Constructor default
        /// </summary>
        public Falcon():base()
        {

        }


        /// <summary>
        /// Constructor base 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="category"></param>
        /// <param name="gender"></param>
        /// <param name="wingSpan"></param>
        /// <param name="quaranteen"></param>
        /// <param name="numberOfDays"></param>
        public Falcon(string ID, string name, double age, CategoryType category, GenderType gender, double wingSpan, bool quaranteen, int numberOfDays)
            : base(string.Empty, string.Empty, category, gender, wingSpan, quaranteen, numberOfDays)
        {


        }


        /// <summary>
        /// Property provides accessor and mutator
        /// for BornInCaptivity
        /// </summary>
        public bool BornInCaptivity
        {

            get { return this.m_bornInCaptivity; }
            set { this.m_bornInCaptivity = value; }

        }


        /// <summary>
        /// Method overrides GetAnimalSpeficData()
        /// </summary>
        /// <returns>overriden string </returns>
        public override string GetAnimalSpecificData()
        {


            string strOut = null;

            string strBornInCaptivity = "not";

            if (m_bornInCaptivity)
            {
                strBornInCaptivity = " ";
            }
            strOut += string.Format("this falcon is  {0} in captivity", strBornInCaptivity);
            strOut += Environment.NewLine + SetFeedingData();
            strOut += Environment.NewLine + BirdInfo();

            return strOut;

        }


        //A VG (ECT A and B) part
        //An abstract method for bird sub class
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        /// </summary>
        public override string SetFeedingData()
        {
            string strOut = "Needs to be fed in mouth";

            return strOut;

        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public override string AnimalInfo()
        //{
        //    string strOut = null;

        //    strOut = string.Format("\t{0,-20}{1, -20}{2, -3}{3, -5}", m_animalID, m_nickName, m_animalAge, m_animalCategory, m_animalGender);

        //    return strOut;

        //}

        /// <summary>
        /// Method string representation of bird data
        /// </summary>
        /// <returns></returns>
        public override string BirdInfo()
        {
            string strOut = null;


            strOut = base.BirdData();

            return strOut;
        }


    }

}