
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AnimalLibrary
{

    public class Boa : Reptile
    {
   
      

 



        /// <summary>
        /// Method overrides GetAnimalSpeficData()
        /// </summary>
        /// <returns>overriden string </returns>
        public override string GetAnimalSpecificData()
        {
            string strIn = base.ReptileData();

            string strOut = null;


            strOut += Environment.NewLine + ReptileInfo();

            //if(m_isPoisonous == true)
            if (strIn.Equals("This reptile is poisonous"))
            {

                strOut += Environment.NewLine + SetPoisonData();
            }

            return strOut;

        }



        //A VG (ECT A and B) part
        //An abstract method for insect sub classes
        /// <summary>
        /// For ll insects objects, info on their invasiveness and stinkynss
        /// should be provided
        /// </summary>
        public override string SetPoisonData()
        {

            string strOut = null;

            strOut = "The poison of this animal is to be treated with amonia";

            return strOut;
        }

        /// <summary>
        /// Method string representation of reptile data
        /// </summary>
        /// <returns></returns>
        public override string ReptileInfo()
        {
            string strOut = null;


            strOut = base.ReptileData();

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