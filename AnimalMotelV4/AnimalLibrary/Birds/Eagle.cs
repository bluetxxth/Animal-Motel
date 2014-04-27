
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;

namespace AnimalLibrary
{

    public class Eagle : Bird
    {

        //instance variables 
        private bool m_bornInCaptivity;


        public Eagle():base()
        {

        }

                public Eagle(string ID, string name, double age, CategoryType category, GenderType gender, double wingSpan, bool quaranteen, int numberOfDays)
            : base(string.Empty, string.Empty, category, gender, wingSpan, quaranteen, numberOfDays)
        {


        }


        /// <summary>
        /// Property provides accessor and mutator
        /// for m_larvalPhase
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

            string strBornInCaptivity = null;

            if (m_bornInCaptivity)
            {
                strBornInCaptivity = "Yes";
            }

            strOut += string.Format("this eagle is born in captivity {0} ", strBornInCaptivity);

            strOut += Environment.NewLine + SetFeedingData();
            strOut += Environment.NewLine + BirdInfo();

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

        //A VG (ECT A and B) part
        //An abstract method for sub classes
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        /// </summary>
        public override string SetFeedingData()
        {
            string strOut = "Needs to be fed in mouth";

            return strOut;

        }


        /// <summary>
        /// Method specific information for birds
        /// </summary>
        /// <returns></returns>
        public override string BirdInfo()
        {
            string strOut = base.BirdData();

            return strOut;
        }



    }

}