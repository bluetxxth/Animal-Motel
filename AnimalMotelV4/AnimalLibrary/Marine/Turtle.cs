﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalLibrary
{


    public class Turtle : Marine
    {


  
        /// <summary>
        /// Method overrides GetAnimalSpeficData()
        /// </summary>
        /// <returns>overriden string </returns>
        public override string GetAnimalSpecificData()
        {

       
            string strOut = null;

          


            strOut += Environment.NewLine + MarineInfo();
            strOut += Environment.NewLine + SetDangerLevel();

            return strOut;

        }


        //A VG (ECT A and B) part
        //An abstract method for sub classes
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        public override string MarineInfo()
        {
            string strOut = null;

            strOut = base.MarineData();

            return strOut;
        }


        //A VG (ECT A and B) part
        //An abstract method for sub classes
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        /// </summary>
        public override string SetDangerLevel()
        {
            string strOut = "This animal is not dangerous";

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

    }

}