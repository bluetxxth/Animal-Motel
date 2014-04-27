
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalLibrary.Enums;


namespace AnimalLibrary
{

    public class Butterfly : Insect
    {
        //instance variables
        private bool m_larvaPhase;


        /// <summary>
        /// 
        /// </summary>
        public Butterfly()
        {

        }

        /// <summary>
        /// Constructor1 - default
        /// </summary>
        public Butterfly(string ID, string nickName, double age, CategoryType category, GenderType gender  ):base(ID,  nickName, age, category,  gender)
        {

        }

        /// <summary>
        /// Property provides accessor and mutator
        /// for m_larvalPhase
        /// </summary>
        public bool LarvalPhase
        {

            get { return this.m_larvaPhase; }
            set { this.m_larvaPhase = value; }

        }

        /// <summary>
        /// Method overrides GetAnimalSpeficicData()
        /// </summary>
        /// <returns>overriden strOut</returns>
        public override string GetAnimalSpecificData()
        {

            string strOut = null;

            string strLarval = " not ";
            if (m_larvaPhase)
            {
                strLarval = " ";
            }

            strOut += string.Format("this butterfly is  {0} In the larval phase", strLarval);
            strOut += Environment.NewLine + SetStinkAndInvasiveData();
            strOut += Environment.NewLine + InsectData();

            return strOut;
        }


        //A VG (ECT A and B) part
        /// <summary>
        /// Implementation of abstract method defined in base class
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public override string InsectInfo()
        {
            string strOut = null;

            strOut = base.InsectData();

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
        /// <summary>
        /// Implementation of abstract method defined in base class
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public override string SetStinkAndInvasiveData()
        {
            string strOut = "Butterflies are beautiful.  They do not stink or get aggressive!";
            return strOut;
        }
    }
}
